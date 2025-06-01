using UnityEngine;
using UnityEngine.UI;

public class ChooseColorButton : MonoBehaviour
{
    [SerializeField] private ColorsCircleController _colorsCircleController;

    [SerializeField] private Color _color;

    [SerializeField] private Image _buttonImage;

    public void Init(ColorsCircleController colorsCircleController, Color color)
    {
        _colorsCircleController = colorsCircleController;
        _color = color;
        _buttonImage.color = color;
    }
    
    public void SendColor()
    {
        _colorsCircleController.ChooseColor(_color);
    }

}
