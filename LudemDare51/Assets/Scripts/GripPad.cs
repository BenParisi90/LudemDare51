using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripPad : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Player")
        {
            PlayerMovement.Instance.AttemptGrip();
        }
    }
}