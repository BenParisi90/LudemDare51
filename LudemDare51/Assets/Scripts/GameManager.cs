using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Goal _goal;
    [SerializeField] private Transform _player;
    [SerializeField] private KillFloor _killFloor;

    [SerializeField] private Transform _goalPositions;
    [SerializeField] private GameObject _winGameText;
    [SerializeField] private Transform _environmentRoot;
    [SerializeField] private int _startingLevel;
    private int _levelIndex = 0;
    private int _levelCount;

    private Vector3 _playerStartPosition = Vector3.zero;

    public static GameState GameState = GameState.LEVEL_START;

    public static UnityAction WinLevel;
    public static UnityAction FailLevel;

    void Start()
    {
        _goal.GoalReached.AddListener(Win);
        _timer.TimerExpired.AddListener(Fail);
        _killFloor.HitKillFloor.AddListener(Fail);
        PlayerAnimEvents.WinAnimComplete += SetupLevel;
        PlayerAnimEvents.FailAnimComplete += ResetLevel;

        _winGameText.SetActive(false);

        _levelCount = _goalPositions.childCount;

        _levelIndex = _startingLevel;



        SetupLevel();
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
        _timer.ResetTimer();
        _levelIndex ++;
        _player.position = _goal.transform.position;
        WinLevel.Invoke();
    }

    private void Fail()
    {
        GameState = GameState.FAIL;
        _timer.StopTimer();
        FailLevel.Invoke();
    }

    private void SetupLevel()
    {
        DisableAllLevels();
        EnableLevel(_levelIndex);
        EnableLevel(_levelIndex + 1);

        //if there are no more levels to set up, win the game
        if(_levelIndex < _levelCount)
        {
            _goal.SetGoal(_goalPositions.GetChild(_levelIndex).position);
            _goal.transform.position = _goalPositions.GetChild(_levelIndex).position;
            if(_levelIndex > 0)
            {
                _player.transform.position = _goalPositions.GetChild(_levelIndex - 1).position;
            }
            GameState = GameState.LEVEL_START;
        }
        else
        {
            GameState = GameState.WIN_GAME;
            _winGameText.SetActive(true);
        }
        
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
        GameState = GameState.LEVEL_START;
    }

    private void DisableAllLevels()
    {
        for(int i = 0; i < _environmentRoot.childCount; i ++)
        {
            _environmentRoot.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void EnableLevel(int targetLevel)
    {
        if(targetLevel >= _environmentRoot.childCount)
        {
            return;
        }

        _environmentRoot.GetChild(targetLevel).gameObject.SetActive(true);
    }
}
