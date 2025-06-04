using UnityEngine;
using UnityEngine.UI;

public class SoundEffectPerformer : MonoBehaviour
{
    [SerializeField] private AudioClip _effectClip;
    private AudioService _service;


    private void Start()
    {
        _service = AudioService.Instance;
        GetComponent<Button>().onClick.AddListener(PlayClip);
    }

    private void PlayClip()
    {
        _service.PlayEffect(_effectClip);
    }

}
