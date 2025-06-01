using UnityEngine;
using UnityEngine.UI;

public class SettingsSliderSaver : MonoBehaviour
{
    [SerializeField] private string _namePlayerPrefsToSave;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.value = PlayerPrefs.GetFloat(_namePlayerPrefsToSave, 1f);
    }

    public void SaveValueToPlayerPrefs(float value)
    {
        PlayerPrefs.SetFloat(_namePlayerPrefsToSave, value);
    }

}
