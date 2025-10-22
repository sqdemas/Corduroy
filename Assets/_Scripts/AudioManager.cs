using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return; // stop setup on duplicates
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // initialize each sound with its own AudioSource
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("AudioManager: Sound not found -> " + sound);
            return;
        }
        if (s.source == null)
        {
            Debug.LogWarning("AudioManager: Source missing for -> " + sound);
            return;
        }
        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("AudioManager: Sound not found -> " + sound);
            return;
        }
        if (s.source == null)
        {
            Debug.LogWarning("AudioManager: Source missing for -> " + sound);
            return;
        }
        s.source.Stop();
    }
}
