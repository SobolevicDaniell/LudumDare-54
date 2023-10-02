using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);

    }

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX += mouseX;
        rotationY -= mouseY;
        
        rotationX = Mathf.Clamp(rotationX, -180f, 180f);
        rotationY = Math.Clamp(rotationY, -90f , 90f);


        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
