using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerMovement : MonoBehaviour
{
    [SerializeField] private XRNode inputSource;
    [SerializeField] [Range(0f, 5f)] private float speed = 1f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float additionalHeight = 0.2f;

    private Vector2 inputAxis;
    private CharacterController character;
    private XRRig xrRig;
    private float fallingspeed;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        xrRig = GetComponent<XRRig>();
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        
        Quaternion headYaw = Quaternion.Euler(0, xrRig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * (Time.fixedDeltaTime * speed));

        // Gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingspeed = 0;
        }
        else
        {
            fallingspeed += gravity * Time.fixedDeltaTime;
        }

        character.Move(Vector3.up * (fallingspeed * Time.fixedDeltaTime));
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;

        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);

        return hasHit;
    }

    private void CapsuleFollowHeadset()
    {
        character.height = xrRig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(xrRig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }
}

