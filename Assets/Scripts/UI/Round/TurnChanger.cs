using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnChanger : MonoBehaviour
{
    [SerializeField] private string _roundName; 
    [SerializeField] private string _nextRoundName; 
    [SerializeField] private List<string> _playersList = new List<string>();

    [SerializeField] private int turnTime;

    [SerializeField] private TextMeshProUGUI turnPlayerText;
    [SerializeField] private TextMeshProUGUI turnTimeText;

    [SerializeField] private GameObject _timerObject;
    [SerializeField] private GameObject _colorButtonsObject;
    [SerializeField] private ColorsCircleController _colorsCircleController;

    private int _playerIndex = 0;

    public int PlayerIndex
    {
        get => _playerIndex;
    }

    public event Action timeStartEvent; 
    public event Action timeOverEvent; 


    public void StartTurn()
    {
        if (_playerIndex >= 2)
        {
            SceneManager.LoadSceneAsync(_nextRoundName);
        }
        else
        {
            timeStartEvent += () => turnPlayerText.text = _roundName;
            timeOverEvent += () => turnPlayerText.text = "PLAYER " + _playerIndex.ToString() + "`s TURN";
            StartCoroutine("StartTurnTimerCoroutine");
        }
    }

    private IEnumerator StartTurnTimerCoroutine()
    {
        timeStartEvent?.Invoke();
        for (int i = turnTime; i > 0; i--)
        {
            turnTimeText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        _playerIndex++;
        timeOverEvent?.Invoke();
    }

    void Start()
    {
        timeStartEvent += () => _colorButtonsObject.SetActive(false);
        timeStartEvent += () => _timerObject.SetActive(true);

        timeOverEvent += () => _timerObject.SetActive(false);
        timeOverEvent += () => _colorButtonsObject.SetActive(true);

        timeStartEvent += _colorsCircleController.CreateRandomSequence;
        timeOverEvent += _colorsCircleController.ClearViewAll;

        StartTurn();
    }
}
