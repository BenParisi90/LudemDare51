using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public UnityEvent GoalReached;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            GoalReached.Invoke();
        }
    }
}