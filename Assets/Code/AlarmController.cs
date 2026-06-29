using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    private AudioSource alarmAudio;
    private bool isAlarmOn = false;

    void Start()
    {
        // ดึง AudioSource จากวัตถุ
        alarmAudio = GetComponent<AudioSource>();
        if (alarmAudio == null)
        {
            Debug.LogError("AudioSource not found on this object!");
        }
    }

    public void ToggleAlarm()
    {
        if (alarmAudio != null)
        {
            if (isAlarmOn)
            {
                alarmAudio.Stop(); // หยุดเสียง
            }
            else
            {
                alarmAudio.Play(); // เล่นเสียง
            }
            isAlarmOn = !isAlarmOn; // สลับสถานะ
        }
    }
}
