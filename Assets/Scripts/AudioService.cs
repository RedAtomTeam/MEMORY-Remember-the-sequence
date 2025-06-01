using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    static public AudioService Instance;

    [SerializeField] private AudioSource _soundtracksSource;
    [SerializeField] private AudioSource _soundEffectsSource;

    [SerializeField] private List<AudioClip> _soundtracks = new List<AudioClip>();
    private int _soundtrackIndex;

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

    public void SetSoundtracksVolume(float volume)
    {
        _soundtracksSource.volume = volume;
    }

    public void SetSoundEffectsVolume(float volume)
    {
        _soundEffectsSource.volume = volume;
    }

    public void StartSoundtracks()
    {
        _soundtracksSource.UnPause();
    }

    public void StopSoundtracks()
    {
        _soundtracksSource.Pause();
    }

    void Start()
    {
    
    }

    private void PlayNextSoundtrack()
    {
        if (_soundtracks.Count > 0)
        {
            int nextIndex = _soundtrackIndex + 1;
            if (nextIndex >= _soundtracks.Count)
            {
                nextIndex = 0;
            }
            _soundtracksSource.clip = _soundtracks[nextIndex];
        }
    }


    void Update()
    {
        if (_soundtracksSource.clip != null && (_soundtracksSource.clip.length - _soundtracksSource.time) < 0.1f)
        {
            PlayNextSoundtrack();
        }
    }
}
