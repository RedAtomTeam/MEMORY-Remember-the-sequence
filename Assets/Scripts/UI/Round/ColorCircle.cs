using UnityEngine;
using UnityEngine.UI;

public class ColorCircle : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Color _trueCircleColor;


    public void SetTrueColor(Color color)
    {
        _trueCircleColor = color;
        _image.color = color;
    }

    public void ClearView()
    {
        _image.color= Color.white;
    }

    public bool SetColor(Color color)
    {
        if (_trueCircleColor == color)
        {
            _image.color = color;
            return true;
        }
        else
        {
            return false;
        }
    }
}
