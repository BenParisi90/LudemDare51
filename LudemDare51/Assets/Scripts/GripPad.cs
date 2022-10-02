using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripPad : MonoBehaviour
{
    [SerializeField] private bool _breakable = false;
    [SerializeField] private Collider _triggerCollider;
    [SerializeField] private Collider _nonTriggerCollider;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Player")
        {
            PlayerMovement.Instance.AttemptGrip(this);
        }
    }

    public void JumpOff()
    {
        if(_breakable)
        {
            _triggerCollider.gameObject.SetActive(false);
            _nonTriggerCollider.gameObject.SetActive(false);
            ParticleController.Instance.Shatter(transform.position, transform.rotation);
        }
    }
}