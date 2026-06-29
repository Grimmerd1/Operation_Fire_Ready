using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co2Shooter : MonoBehaviour
{
      [SerializeField] private ParticleSystem waterSpray; // ลิงก์ Particle System
    [SerializeField] private float range = 10f; // ระยะยิงน้ำ
    [SerializeField] private LayerMask Co2Layer; // เลเยอร์ของไฟ
    [SerializeField] private Transform shootPoint; // จุดที่น้ำพุ่งออกมา
    [SerializeField] private AudioSource Co2Sound; // ลิงก์ไปยัง AudioSource

    void Update()
    {
        if (Input.GetMouseButton(0)) // คลิกซ้ายเพื่อฉีดน้ำ
        {
            if (!waterSpray.isPlaying)
                waterSpray.Play();

            if (Co2Sound != null && !Co2Sound.isPlaying)
                Co2Sound.Play(); // เล่นเสียงน้ำเมื่อเริ่มฉีดน้ำ

            ShootWater();
        }
        else
        {
            if (waterSpray.isPlaying)
                waterSpray.Stop();

            if (Co2Sound != null && Co2Sound.isPlaying)
                Co2Sound.Stop(); // หยุดเสียงน้ำเมื่อหยุดฉีดน้ำ
        }
    }

    void ShootWater()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, range, Co2Layer))
        {
            Debug.Log("Hit: " + hit.collider.name);
            if (hit.collider.CompareTag("Co2"))
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
