using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _timerText; 
    [SerializeField] private float _totalLevelTime = 10;
    private float _levelStartTime = 0;
    private float _remainingLevelTime = 0;
    private bool _started = false;

    public UnityEvent TimerExpired;

    // Update is called once per frame
    void Update()
    {
        if(_started)
        {
            _remainingLevelTime -= Time.deltaTime;
            _timerText.text = _remainingLevelTime.ToString("F2");
            if(_remainingLevelTime <= 0)
            {
                _timerText.text = "0.00";
                TimerExpired.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        _levelStartTime = Time.time;
        _started = true;
        _remainingLevelTime = _totalLevelTime;
    }

    public void StopTimer()
    {
        _started = false;
    }
}
