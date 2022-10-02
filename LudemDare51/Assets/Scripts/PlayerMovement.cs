using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] float _jumpForce = 1;
    [SerializeField] float _gravity;
    [SerializeField] AudioSource _jumpSound;
    [SerializeField] AudioSource _gripSound;
    public AudioSource ShatterSound => _shatterSound;
    [SerializeField] AudioSource _shatterSound;
    private float _currentJumpSpeed = 0;
    private bool _hasJumped = false;
    public bool Grounded => _grounded;
    private bool _grounded = true; 
    
    private bool _gripping = false;
    private bool _canGrip = true;
    private float _lastGripTime = 0;
    private GripPad _currentGripPad;

    void Start()
    {
        Instance = this;
        GameManager.ResetLevel += ResetLevel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.GameState != GameState.PLAYING)
        {
            return;
        }

        Vector3 movement = Vector3.zero;

        if(!_gripping)
        {
            movement.z += InputManager.forward ? 1 : 0;
            movement.z -= InputManager.backward ? 1 : 0;
            movement.x -= InputManager.left ? 1 : 0;
            movement.x += InputManager.right ? 1 : 0;
            movement *= _moveSpeed * Time.deltaTime;
        }

        _grounded = IsGrounded();
        if(Grounded || _gripping)
        {
            if(Grounded)
            {
                _currentGripPad = null;
            }
            if(InputManager.jump && !_hasJumped)
            {
                _currentJumpSpeed = _jumpForce;
                _jumpSound.Play();
                _hasJumped = true;
                if(_gripping)
                {
                    _gripping = false;
                    _currentGripPad.JumpOff();
                }
            }
        }
        else
        {
            _currentJumpSpeed -= _gravity * Time.deltaTime;
        }

        movement.y += _currentJumpSpeed;

        _characterController.Move(movement);

        if(_hasJumped && !InputManager.jump)
        {
            _hasJumped = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.1f, LayerMask.GetMask("Environment"));
    }

    public void AttemptGrip(GripPad gripPad)
    {
        if(gripPad == _currentGripPad)
        {
            return;
        }
        if(Grounded)
        {
            return;
        }
        _gripping = true;
        _lastGripTime = Time.time;
        _currentJumpSpeed = 0;
        _currentGripPad = gripPad;
        gripPad.PlayGripPadAnim();
        _gripSound.Play();
    }

    private void ResetLevel()
    {
        _currentGripPad = null;
        _gripping = false;
        
    }
}
