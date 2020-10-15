using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerMovement : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics inputDeviceCharacteristics;
    [SerializeField] private Transform XrRig;
    [SerializeField] private Transform Camera;
    [SerializeField, Range(0f,2f)] private float speed=0.5f;
    private InputDevice targetDevice;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);
          if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 triggerValue) && triggerValue != Vector2.zero)
        {
            // Vector3 vec = Camera.forward * ;
              
            //XrRig.Translate(new Vector3(vec.x, XrRig.position.y, vec.z), Space.World);
            XrRig.Translate(-triggerValue.y * speed, 0, 0);
            XrRig.Translate(0, 0, triggerValue.x * speed);
            
        }
       
    }
}

