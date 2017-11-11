using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowMouse : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis


    public bool rotateX;
    public bool rotateY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        if (rotateY) rotY += mouseX * mouseSensitivity * Time.deltaTime;
        else rotY = transform.eulerAngles.y;

        if (rotateX) rotX += mouseY * mouseSensitivity * Time.deltaTime;
        else rotX = transform.eulerAngles.x;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
