using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Goal _goal;
    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _introScreen;

    private Vector3 _playerStartPosition = Vector3.zero;

    public static GameState GameState = GameState.LEVEL_START;

    public static UnityAction WinLevel;
    public static UnityAction FailLevel;

    void Start()
    {
        _goal.GoalReached.AddListener(Win);
        _timer.TimerExpired.AddListener(Fail);
        PlayerAnimEvents.WinAnimComplete += ResetLevel;
        PlayerAnimEvents.FailAnimComplete += ResetLevel;
    }

    void Update()
    {
        switch(GameState)
        {
            case GameState.LEVEL_START:
                if(Input.anyKeyDown)
                {
                    BeginLevel();
                    
                }
                break;
        }
        
    }

    public void Win()
    {
        GameState = GameState.SUCCESS;
        _timer.StopTimer();
        WinLevel.Invoke();
    }

    private void Fail()
    {
        GameState = GameState.FAIL;
        _timer.StopTimer();
        FailLevel.Invoke();
    }

    private void BeginLevel()
    {
        _timer.StartTimer();
        GameState = GameState.PLAYING;
        _playerStartPosition = _player.position;
    }

    private void ResetLevel()
    {
        _player.position = _playerStartPosition;
    }
}
