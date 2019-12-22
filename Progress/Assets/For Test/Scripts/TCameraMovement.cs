using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCameraMovement : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float sensitivity;
    [SerializeField] private float clampX;

    [Space]

    [Header("Reference")]
    [SerializeField] private Transform playerBody;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        
    }

    private float mouseX;
    private float mouseY;
    private float xRotation;

    void Update()
    {
        MouseRotateInputs();
    }

    void FixedUpdate()
    {
        MouseRotate();
    }

    void MouseRotate()
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clampX, clampX);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void MouseRotateInputs()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    }

}
