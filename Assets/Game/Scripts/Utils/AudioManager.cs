using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource sfxSource;
    private Dictionary<AudioClip, AudioSource> loopingSources = new Dictionary<AudioClip, AudioSource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayLoopingSound(AudioClip clip, float volume)
    {
        if (clip == null) return;

        if (loopingSources.ContainsKey(clip)) return;

        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.clip = clip;
        newSource.loop = true;
        newSource.volume = volume;
        newSource.Play();

        loopingSources.Add(clip, newSource);
    }

    public void StopLoopingSound(AudioClip clip)
    {
        if (clip == null) return;

        if (loopingSources.ContainsKey(clip))
        {
            AudioSource sourceToStop = loopingSources[clip];

            sourceToStop.Stop();

            Destroy(sourceToStop);

            loopingSources.Remove(clip);
        }
    }
}