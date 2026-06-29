using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
     private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        // บันทึกตำแหน่งและการหมุนเริ่มต้น
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void ResetPosition()
    {
        // คืนถังดับเพลิงไปยังตำแหน่งเดิม
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
