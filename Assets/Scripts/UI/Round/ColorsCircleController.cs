using System;
using System.Collections.Generic;
using UnityEngine;

public class ColorsCircleController : MonoBehaviour
{
    [SerializeField] private AudioClip _correctColorSound;
    [SerializeField] private AudioClip _incorrectColorSound;

    [SerializeField] private ChooseColorController _chooseColorController;
    [SerializeField] private TurnChanger _turnChanger;
    [SerializeField] private EndWindowController _endWindowController;

    [SerializeField] private List<ColorCircle> _circles = new List<ColorCircle>();

    [SerializeField] private List<Color> _colorsToGenerate;

    private int _targetCircle = 0;

    public event Action incorrectColorEvent;
    public event Action correctColorEvent;
    public event Action<AudioClip> correctColorSoundEvent;
    public event Action<AudioClip> incorrectColorSoundEvent;


    private void OnEnable()
    {
        correctColorSoundEvent += AudioService.Instance.PlayEffect;
        incorrectColorSoundEvent += AudioService.Instance.PlayEffect;
    }

    private void OnDisable()
    {
        correctColorSoundEvent -= AudioService.Instance.PlayEffect;
        incorrectColorSoundEvent -= AudioService.Instance.PlayEffect;
    }

    public void CreateRandomSequence()
    {
        var colors = new List<Color>();
        for (int i = 0; i < _circles.Count; i++)
        {
            var color = _colorsToGenerate[UnityEngine.Random.Range(0, _colorsToGenerate.Count - 1)];
            _circles[i].SetTrueColor(color);
            colors.Add(color);
        }
        _chooseColorController.Init(colors);
    }

    public void ClearViewAll()
    {
        for (int i = 0; i < _circles.Count; i++)
        {
            _circles[i].ClearView();
        }
    }

    public void ChooseColor(Color color)
    {
        if (_circles[_targetCircle].SetColor(color))
        {
            correctColorEvent?.Invoke();
            correctColorSoundEvent?.Invoke(_correctColorSound);
            _targetCircle++;
            if (_targetCircle == _circles.Count)
            {
                _targetCircle = 0;
                _turnChanger.StartTurn();
            }
        }
        else
        {
            incorrectColorEvent?.Invoke();
            incorrectColorSoundEvent?.Invoke(_incorrectColorSound);
            _turnChanger.gameObject.SetActive(false);
            _endWindowController.EndGame();
        }
    }
}
