using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private bool isWalking;

    private void Update() {
        /*var inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        } else if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        } else if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;*/

        var inputVector = gameInput.GetMovementVectorNormalized();

        var moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * (speed * Time.deltaTime);

        isWalking = moveDir != Vector3.zero;
        
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking() {
        return isWalking;
    }
}