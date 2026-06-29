using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderShoot : MonoBehaviour
{
       [SerializeField] private ParticleSystem waterSpray; // ลิงก์ Particle System
    [SerializeField] private float range = 10f; // ระยะยิงน้ำ
    [SerializeField] private LayerMask PowderLayer; // เลเยอร์ของไฟ
    [SerializeField] private Transform shootPoint; // จุดที่น้ำพุ่งออกมา
    [SerializeField] private AudioSource PowderSound; // ลิงก์ไปยัง AudioSource

    void Update()
    {
        if (Input.GetMouseButton(0)) // คลิกซ้ายเพื่อฉีดน้ำ
        {
            if (!waterSpray.isPlaying)
                waterSpray.Play();

            if (PowderSound != null && !PowderSound.isPlaying)
                PowderSound.Play(); // เล่นเสียงน้ำเมื่อเริ่มฉีดน้ำ

            ShootWater();
        }
        else
        {
            if (waterSpray.isPlaying)
                waterSpray.Stop();

            if (PowderSound != null && PowderSound.isPlaying)
                PowderSound.Stop(); // หยุดเสียงน้ำเมื่อหยุดฉีดน้ำ
        }
    }

    void ShootWater()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, range, PowderLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);
            if (hit.collider.CompareTag("Powder"))
            {
                Debug.Log("Fire detected!");
                FireController fire = hit.collider.GetComponent<FireController>();
                if (fire != null)
                {
                    fire.Extinguish();
                    Debug.Log("Extinguish called!");
                }
            }
        }
        else
        {
            Debug.Log("Missed!");
        }
    }
}
