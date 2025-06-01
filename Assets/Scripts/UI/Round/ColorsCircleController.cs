using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ColorsCircleController : MonoBehaviour
{

    [SerializeField] private ChooseColorController _chooseColorController;
    [SerializeField] private TurnChanger _turnChanger;
    [SerializeField] private EndWindowController _endWindowController;

    [SerializeField] private List<ColorCircle> circles = new List<ColorCircle>();

    [SerializeField] private List<Color> _colorsToGenerate;

    private int targetCircle = 0;


    public void CreateRandomSequence()
    {
        var colors = new List<Color>();
        for (int i = 0; i < circles.Count; i++)
        {
            var color = _colorsToGenerate[UnityEngine.Random.Range(0, _colorsToGenerate.Count - 1)];
            circles[i].SetTrueColor(color);
            colors.Add(color);
        }
        _chooseColorController.Init(colors);
    }

    public void ClearViewAll()
    {
        for (int i = 0; i < circles.Count; i++)
        {
            circles[i].ClearView();
        }
    }

    public void ChooseColor(Color color)
    {
        if (circles[targetCircle].SetColor(color))
        {
            targetCircle++;
            if (targetCircle == circles.Count)
            {
                targetCircle = 0;
                _turnChanger.StartTurn();
            }
        }
        else
        {
            _turnChanger.gameObject.SetActive(false);
            _endWindowController.EndGame();
        }
    }
}
