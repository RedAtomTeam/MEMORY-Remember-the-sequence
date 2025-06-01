using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ChooseColorController : MonoBehaviour
{
    [SerializeField] private ColorsCircleController _colorsCircleController;

    [SerializeField] private List<ChooseColorButton> _colorButtons;


    public void Init(List<Color> colors)
    {
        colors = Shuffle(colors);
        for (int i = 0; i < colors.Count; i++) 
        {
            _colorButtons[i].Init(_colorsCircleController, colors[i]);
        }
    }

    private List<Color> Shuffle(List<Color> colors)
    {
        var newColors = new List<Color>();

        int count = colors.Count;
        for (int i = 0; i < count; i++)
        {
            var newColorIndex = Random.Range(0, colors.Count);
            newColors.Add(colors[newColorIndex]);
            colors.RemoveAt(newColorIndex);
        }

        return newColors;
    }

}
