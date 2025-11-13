using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer:MonoBehaviour
{


    /// <summary>
    /// Run Function after time sec
    /// </summary>
    /// <param name="time"></param>
    /// <param name="function"></param>
    /// <returns></returns>
    public void Delay (float time,Action function)
    {
        StartCoroutine(TimerDelay_Courotine(time, function));
    }
    IEnumerator TimerDelay_Courotine(float time,Action function)
    {
        yield return new WaitForSeconds(time);
        function?.Invoke();
    }

}