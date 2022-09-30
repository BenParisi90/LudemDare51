using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(_playerTransform.position, _playerTransform.rotation);
    }
}
