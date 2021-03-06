﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    [SerializeField] private GameObject HandModel;
    [SerializeField] private XRNode inputSource;
    private GameObject handModelInstance;
    //private InputDevice targetDevice;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //List<InputDevice> devices = new List<InputDevice>();
        //InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);
        //foreach (var item in devices)
        //{
        //    Debug.Log(item.name);
        //}
        //if (devices.Count > 0)
        //{
        //    targetDevice = devices[0];
        //}

        handModelInstance = Instantiate(HandModel, transform);
        animator = handModelInstance.GetComponent<Animator>();
        UpdateHandAnimation();
    }

    void UpdateHandAnimation()
    {

        var targetDevice = InputDevices.GetDeviceAtXRNode(inputSource);
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            animator.SetFloat("Trigger", triggerValue);

        }else{
            animator.SetFloat("Trigger", 0f);
        }
       
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
        {
            animator.SetFloat("Grip", gripValue);

        }else{
            animator.SetFloat("Grip", 0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        UpdateHandAnimation();
        // if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        // {
        //     Debug.Log("Primaty Button pressed");
        // }

        // if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        // {
        //     Debug.Log("Trigger pressed: " + triggerValue);

        // }

        // if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        // {
        //     Debug.Log("Primary Touchpad: " + primary2DAxisValue);
        // }
    }
}
