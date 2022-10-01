using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private CharacterController _characterController;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameState != GameState.PLAYING)
        {
            return;
        }

        Vector3 movement = Vector3.zero;
        movement.z += InputManager.forward ? _moveSpeed : 0;
        movement.z -= InputManager.backward ? _moveSpeed : 0;
        movement.x -= InputManager.left ? _moveSpeed : 0;
        movement.x += InputManager.right ? _moveSpeed : 0;
        _characterController.Move(movement);
    }
}
