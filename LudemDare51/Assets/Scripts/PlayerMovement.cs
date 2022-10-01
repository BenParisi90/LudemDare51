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
        movement.z += InputManager.forward ? 1 : 0;
        movement.z -= InputManager.backward ? 1 : 0;
        movement.x -= InputManager.left ? 1 : 0;
        movement.x += InputManager.right ? 1 : 0;
        movement *= _moveSpeed * Time.deltaTime;
        _characterController.Move(movement);
    }
}
