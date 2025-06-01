using TMPro;
using UnityEngine;

public class EndWindowController : MonoBehaviour
{
    [SerializeField] private TurnChanger _turnChanger;

    [SerializeField] private GameObject _endPanel;
    [SerializeField] private TextMeshProUGUI _whoWinText;


    public void EndGame()
    {
        int whoIsLoose = _turnChanger.PlayerIndex;
        int whoIsWin = whoIsLoose == 1 ? 2 : 1;
        _whoWinText.text = "PLAYER " + whoIsWin.ToString() + " WIN";
        _endPanel.SetActive(true);
    }


}
