using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
   [SerializeField] private ParticleSystem fireEffect; // Particle System ของไฟ
    [SerializeField] private float health = 1000f; // พลังชีวิตของไฟ
    [SerializeField] private float extinguishRate = 1f; // อัตราการลดพลังไฟ
    [SerializeField] private ParticleSystem.EmissionModule emissionModule; // สำหรับควบคุมการปล่อยไฟ
    [SerializeField] private AudioSource fireSound; // เสียงไฟ
    [SerializeField] private AudioSource extinguishSound; // เสียงไฟดับ

    private bool isExtinguished = false; // สถานะการดับไฟ

    private void Start()
    {
        if (fireEffect != null)
        {
            emissionModule = fireEffect.emission; // ดึงโมดูล Emission ของไฟ

            // เริ่มเสียงไฟทันทีที่วัตถุเริ่มทำงาน
            if (fireSound != null)
            {
                fireSound.Play();
            }
        }
    }

    public void Extinguish()
    {
        if (isExtinguished) return; // ถ้าไฟดับแล้ว ไม่ต้องทำอะไร

        health -= extinguishRate; // ลดพลังไฟ
        Debug.Log("Health: " + health);

        if (health > 0)
        {
            // ลดอัตราการปล่อยของ Particle System ตามสัดส่วนพลังไฟ
            float emissionRate = Mathf.Lerp(0, 50, health / 1000f); // ปรับตามสัดส่วนพลังชีวิต
            emissionModule.rateOverTime = emissionRate;
        }
        else
        {
            // ดับไฟเมื่อพลังเหลือ 0
            if (fireEffect != null)
            {
                fireEffect.Stop(); // หยุด Particle System
            }

            // หยุดเสียงไฟ
            if (fireSound != null && fireSound.isPlaying)
            {
                fireSound.Stop();
            }

            // เล่นเสียงไฟดับ
            if (extinguishSound != null && !isExtinguished)
            {
                extinguishSound.Play();
            }

            isExtinguished = true; // ตั้งสถานะเป็นดับไฟแล้ว
            Debug.Log("Fire extinguished!");
        }
    }
}
