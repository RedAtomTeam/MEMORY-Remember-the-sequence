using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorCircle : MonoBehaviour
{
    [SerializeField] private Image image;
    private Color trueCircleColor;

    public void SetTrueColor(Color color)
    {
        trueCircleColor = color;
        image.color = color;
    }

    public void ClearView()
    {
        image.color= Color.white;
    }

    public bool SetColor(Color color)
    {
        if (trueCircleColor == color)
        {
            image.color = color;
            return true;
        }
        else
        {
            return false;
        }
    }
}
