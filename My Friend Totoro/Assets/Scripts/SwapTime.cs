using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTime : MonoBehaviour
{
    public LightingManager lightingManager;
    public delegate void Transition();
    public static event Transition TransitionDone;
    private bool changeToNight = false;

    private void Start()
    {
        ChatTotoro.ChatDone += ChangeToNight;
        EndFirstDay.EndDaySecret += SecretChangeToNight;
    }

    void SecretChangeToNight() {
        EndFirstDay.EndDaySecret -= SecretChangeToNight;
        changeToNight = true;
        StartCoroutine(TimerCoroutine());
    }


    void ChangeToNight() {
        changeToNight = true;
        StartCoroutine(TimerCoroutine());
        
    }

    void ChangeToDay() {
        changeToNight = false;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (changeToNight == true)
            lightingManager.TimeOfDay = 0f;
        else
            lightingManager.TimeOfDay = 11f;

        if (TransitionDone != null)
        {
            TransitionDone();
        }
    }
}
