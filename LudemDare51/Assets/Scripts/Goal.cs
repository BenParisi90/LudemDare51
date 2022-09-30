using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            Debug.Log("Goal Complete");
        }
    }
}
