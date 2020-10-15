using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSomething : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private bool hasTriggered = false;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private RandomDarkness darkness;
    

    public void Trigger()
    {
        if (hasTriggered)
        {
            return;
        }

        hasTriggered = true;
        StartCoroutine(cameraShake.Shake(.5f, .2f));
        StartCoroutine(darkness.Flicker(.15f, .2f));
    }
}
