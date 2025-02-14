using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 300f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame¸
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") *mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        
        xRotation = Math.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(xRotation,yRotation , 0f);

        
    }
}
