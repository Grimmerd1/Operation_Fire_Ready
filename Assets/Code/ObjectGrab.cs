using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    public Transform holdPoint;
    public float grabRange = 3f;
    public LayerMask grabbableLayer;

    private GameObject grabbedObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedObject == null)
            {
                TryGrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.T)) // กด T เพื่อคืนตำแหน่งเดิม
    {
        if (grabbedObject != null)
        {
            grabbedObject.GetComponent<Position>().ResetPosition();
            ReleaseObject();
        }
    }
    }

    void TryGrabObject()
{
    RaycastHit hit;
    // ใช้ SphereCast เพื่อตรวจจับวัตถุรอบๆ เส้น Ray
    if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, grabRange, grabbableLayer))
    {
        grabbedObject = hit.collider.gameObject; // อ้างอิงวัตถุที่ตรวจจับได้
        Rigidbody objectRigidbody = grabbedObject.GetComponent<Rigidbody>();

        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true; // ปิดฟิสิกส์ชั่วคราว
            objectRigidbody.velocity = Vector3.zero; // หยุดการเคลื่อนที่
            objectRigidbody.angularVelocity = Vector3.zero; // หยุดการหมุน

            grabbedObject.transform.SetParent(holdPoint); // ตั้งเป็นลูกของ HoldPoint
            grabbedObject.transform.localPosition = Vector3.zero; // ตั้งตำแหน่งให้ตรง HoldPoint
            grabbedObject.transform.localRotation = Quaternion.identity; // ตั้งการหมุนให้ตรง HoldPoint
        }
    }
}

    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            Rigidbody objectRigidbody = grabbedObject.GetComponent<Rigidbody>();
            if (objectRigidbody != null)
            {
                objectRigidbody.isKinematic = false;
            }
            grabbedObject.transform.parent = null;
            grabbedObject = null;
        }
    }
}
