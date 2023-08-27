using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    private void Update() {
        var inputVector = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.W)) {
            inputVector.y = +1;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            inputVector.y = -1;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            inputVector.x = -1;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        var moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * (speed * Time.deltaTime);

        transform.forward = moveDir;
    }
}