using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Goal _goal;

    [SerializeField] private GameObject _introScreen;

    public static GameState GameState = GameState.LEVEL_START;

    void Start()
    {
        _goal.GoalReached.AddListener(WinLevel);
        _timer.TimerExpired.AddListener(FailLevel);
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

    public void WinLevel()
    {
        GameState = GameState.SUCCESS;
        _timer.StopTimer(); 
    }

    private void FailLevel()
    {
        GameState = GameState.FAIL;
        _timer.StopTimer();
    }
}
