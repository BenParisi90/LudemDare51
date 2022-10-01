using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private float _minFieldOfView = 60;
    [SerializeField] private float _maxFieldOfView = 100;
    [SerializeField] private float _fieldOfViewSpeedChange;
    [SerializeField] private Vector3 _cameraMaxLocalPosition;
    private Vector3 _cameraMinLocalPosition;

    private Vector3 _prevPosition;

    void Start()
    {
        _cameraMinLocalPosition = _camera.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.SetPositionAndRotation(_playerTransform.position, _playerTransform.rotation);

        bool moving = transform.position != _prevPosition;
        float targetFieldOfView = moving ? _maxFieldOfView : _minFieldOfView;
        _camera.fieldOfView += (targetFieldOfView - _camera.fieldOfView) * _fieldOfViewSpeedChange;
        _prevPosition = transform.position;

        float cameraZoomPercent = Mathf.InverseLerp(_minFieldOfView, _maxFieldOfView, _camera.fieldOfView);
        _camera.transform.localPosition = Vector3.Lerp(_cameraMinLocalPosition, _cameraMaxLocalPosition, cameraZoomPercent);
    }
}
