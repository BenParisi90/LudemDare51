using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] float _jumpForce = 1;
    [SerializeField] float _gravity;
    private float _currentJumpSpeed = 0;
    public bool Grounded => _grounded;
    private bool _grounded = true; 
    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.GameState != GameState.PLAYING)
        {
            return;
        }

        Vector3 movement = Vector3.zero;
        movement.z += InputManager.forward ? 1 : 0;
        movement.z -= InputManager.backward ? 1 : 0;
        movement.x -= InputManager.left ? 1 : 0;
        movement.x += InputManager.right ? 1 : 0;
        movement *= _moveSpeed * Time.deltaTime;

        _grounded = IsGrounded();
        if(Grounded)
        {
            if(InputManager.jump)
            {
                _currentJumpSpeed = _jumpForce;
            }
        }
        else
        {
            _currentJumpSpeed -= _gravity * Time.deltaTime;
        }

        movement.y += _currentJumpSpeed;

        _characterController.Move(movement);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.1f, LayerMask.GetMask("Environment"));
    }
}
