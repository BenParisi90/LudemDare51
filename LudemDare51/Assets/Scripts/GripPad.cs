using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripPad : MonoBehaviour
{
    [SerializeField] private bool _breakable = false;
    [SerializeField] private Collider _triggerCollider;
    [SerializeField] private Collider _nonTriggerCollider;

    void Start()
    {
        GameManager.ResetLevel += Reset;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerMovement.Instance.AttemptGrip(this);
        }
    }

    public void PlayGripPadAnim()
    {
        MaterialController.Instance.StartGrip();
    }

    public void JumpOff()
    {
        if(_breakable)
        {
            _triggerCollider.gameObject.SetActive(false);
            _nonTriggerCollider.gameObject.SetActive(false);
            ParticleController.Instance.Shatter(transform.position, transform.rotation);
            PlayerMovement.Instance.ShatterSound.Play();
        }
    }

    void Reset()
    {
        _triggerCollider.gameObject.SetActive(true);
        _nonTriggerCollider.gameObject.SetActive(true);
    }
}