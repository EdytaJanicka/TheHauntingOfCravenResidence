﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffectOnObjects : MonoBehaviour
{
    public CanvasGroup Panel1;

    void Start()
    {
        
    }

    //public void FadeOut()
  //  {
   //     StartCoroutine(FadeCanvasGroup(Panel1, Panel1.alpha, 0, .5f));
   // }


    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeCanvasGroup(Panel1, Panel1.alpha, 1, .5f));
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(FadeCanvasGroup(Panel1, Panel1.alpha, 0, .5f));
    }

}
