using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
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
}
}
