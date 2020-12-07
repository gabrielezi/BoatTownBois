using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public bool loop;
    public AudioClip clip;
    public float replayDelay;

    [Range(0f, 1f)] public float volume;
}
