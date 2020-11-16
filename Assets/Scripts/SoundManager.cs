using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public bool playSounds = true;
    
    private Dictionary<string, AudioSource> _audioSources;
    private Dictionary<string, AudioSource> _playingAudioSources;
    private Dictionary<string, float> _soundReplayDelays;
    private Dictionary<string, float> _soundLastPlayedTimers;
    private string _playingBackgroundSoundName;

    private void Awake()
    {
        _audioSources = new Dictionary<string, AudioSource>();
        _soundReplayDelays = new Dictionary<string, float>();
        _soundLastPlayedTimers = new Dictionary<string, float>();
        
        foreach (var sound in sounds)
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = sound.clip;
            audioSource.volume = sound.volume;
            audioSource.loop = sound.loop;

            _audioSources.Add(sound.name, audioSource);
            _soundReplayDelays.Add(sound.name, sound.replayDelay);
        }
    }

    private void Start()
    {
        PlayBackgroundSound("Theme");
    }

    public void PlayBackgroundSound(string soundName)
    {
        if (_playingBackgroundSoundName != null)
        {
            StopSound(soundName);
        }
        _playingBackgroundSoundName = soundName;
        
        PlaySound(soundName);
    }

    public void StopSound(string soundName)
    {
        if (!_audioSources.TryGetValue(soundName, out var sound)) {
            Debug.LogWarning("Sound " + soundName + " not found.");
            
            return;
        }
        sound.Stop();
    }

    public void PlaySound(string soundName)
    {
        if (
            !playSounds
            || !CanPlay(soundName)
            || !_audioSources.TryGetValue(soundName, out var sound)
        ) {
            return;
        }
        
        sound.Play();
        _soundLastPlayedTimers[soundName] = Time.time;
    }

    private bool CanPlay(string soundName)
    {
        if (
            !_soundLastPlayedTimers.TryGetValue(soundName, out var lastPlayed)
            || !_soundReplayDelays.TryGetValue(soundName, out var replayDelay)
        ) {
            return true;
        }

        return lastPlayed + replayDelay < Time.time;
    }
}
