using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEarthquake : MonoBehaviour
{
    // Update is called once per frame
    
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private RandomDarkness darkness;
    [SerializeField] private float predelay = 1f;

    [SerializeField] private float duration = 2f;
    [SerializeField] AnimationCurve shakeCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

    private bool hasTriggered = false;

    public void Trigger()
    {
        if (hasTriggered)
        {
            return;
        }

        hasTriggered = true;
        StartCoroutine(cameraShake.Shake(duration, .2f, shakeCurve, predelay));
        StartCoroutine(darkness.Flicker(duration, .1f, predelay));
    }
}
