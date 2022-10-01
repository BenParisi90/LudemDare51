using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Goal _goal;

    [SerializeField] private GameObject _introScreen;

    public static GameState GameState = GameState.LEVEL_START;

    public UnityEvent WinLevel;
    public UnityEvent FailLevel;

    void Start()
    {
        _goal.GoalReached.AddListener(Win);
        _timer.TimerExpired.AddListener(Fail);
    }

    void Update()
    {
        switch(GameState)
        {
            case GameState.LEVEL_START:
                if(Input.anyKeyDown)
                {
                    _timer.StartTimer();
                    GameState = GameState.PLAYING;
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
}
