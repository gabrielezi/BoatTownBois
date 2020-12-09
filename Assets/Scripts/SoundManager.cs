using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] sounds;
    public bool playSounds = true;

    private string _backgroundSoundPlaying;
    private Dictionary<string, AudioSource> _audioSources;
    private Dictionary<string, float> _soundReplayDelays;
    private Dictionary<string, float> _soundLastPlayedTimers;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

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
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_backgroundSoundPlaying == null)
        {
            PlayBackgroundSound("Theme");
        }
    }
    
    public void PlayBackgroundSound(string soundName)
    {
        if (_backgroundSoundPlaying == soundName)
        {
            return;
        }
        
        StopAllSounds();
        PlaySound(soundName);
        _backgroundSoundPlaying = soundName;
    }

    public void StopAllSounds()
    {
        foreach (var audioSource in _audioSources)
        {
            audioSource.Value.Stop();
        }
    }

    public void StopSound(string soundName)
    {
        if (!_audioSources.TryGetValue(soundName, out var sound))
        {
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
        )
        {
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
        )
        {
            return true;
        }

        return lastPlayed + replayDelay < Time.time;
    }
}
