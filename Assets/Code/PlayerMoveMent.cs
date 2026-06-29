using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;

    public Transform playerCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;// ล็อคเมาส์ไว้ที่หน้าจอ
        Cursor.visible = false; 
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // กดปุ่ม Tab เพื่อปลดล็อคเคอร์เซอร์
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    if (Input.GetKeyDown(KeyCode.R)) // R เพื่อล็อคเคอร์เซอร์ใหม่
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
        // การเคลื่อนที่
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        // การหมุนมุมมอง
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // จำกัดมุมเงย/ก้ม

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}

