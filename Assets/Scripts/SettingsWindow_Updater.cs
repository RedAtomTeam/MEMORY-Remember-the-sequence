using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsWindow_Updater : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    public event UnityAction<float> _musicUpdateEvent;
    public event UnityAction<float> _soundUpdateEvent;



    private void Start()
    {
        _musicSlider.onValueChanged.AddListener((float value) => { _musicUpdateEvent?.Invoke(value); });
        _soundSlider.onValueChanged.AddListener((float value) => { _soundUpdateEvent?.Invoke(value); });

        _soundUpdateEvent += AudioService.Instance.SetSoundEffectsVolume;
        _musicUpdateEvent += AudioService.Instance.SetSoundtracksVolume;
    }
}
