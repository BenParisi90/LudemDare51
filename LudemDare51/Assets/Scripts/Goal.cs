using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private ParticleSystem _particleSysytem;
    [SerializeField] private GameObject _ringModel;
    [SerializeField] private AudioSource _goalSound;

    public UnityEvent GoalReached;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            _ringModel.SetActive(false);
            _particleSysytem.Play();
            _goalSound.Play();
            GoalReached.Invoke();
        }
    }

    public void SetGoal(Vector3 targetPosition)
    {
        transform.position = targetPosition;
        _ringModel.SetActive(true);
    }
}