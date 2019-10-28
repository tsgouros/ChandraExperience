using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    // variable for the camera rig. The camera rig is the gameObject that this
    // script  is connected to.
    private GameObject cameraRig;

    // the camera that is in the center of the cameraRig.
    private GameObject playerCenterEye;

    public float movementSpeed = 0.1f;
    public float turnSpeed = 0.1f;
    private float SimulationRate = 60f;
    public float RotationAmount = 1.5f;
    private float RotationScaleMultiplier = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        cameraRig = this.gameObject;

        playerCenterEye = GameObject.Find("CenterEyeAnchor");

    }

    // Update is called once per frame
    void Update()
    {
        MoveForwardBackward();

        RotateLeftRight();
    }

    /*
     * A function to handle moving backwards and forwards.
     */
    private void MoveForwardBackward()
    {
        //  logic for moving camera rig forward/backward with left thumb stick.
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp,
                        OVRInput.Controller.LTouch) ||
           OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown,
                        OVRInput.Controller.LTouch))
        {
            // The thumbstick state represented as a vector.
            Vector2 thumbStickState =
                OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick,
                             OVRInput.Controller.LTouch);

            Vector3 faceForward = playerCenterEye.transform.forward;

            if (thumbStickState.y > 0 || thumbStickState.y < 0)
            { // Moving forward.
                Debug.Log("Moving...");
                cameraRig.transform.position +=
                    faceForward * movementSpeed * thumbStickState.y;
            }
        }
    }

    /*
     * A function to handle rotating.
     */
    private void RotateLeftRight()
    {
        //  logic for turning camera rig with left thumb stick.
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft,
                        OVRInput.Controller.LTouch) ||
            OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight,
                        OVRInput.Controller.LTouch))
        {

            Vector3 euler = transform.rotation.eulerAngles;
            float rotateInfluence = SimulationRate * Time.deltaTime * RotationAmount * RotationScaleMultiplier;

            // The thumbstick state represented as a vector.
            Vector2 thumbStickState =
                OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick,
                             OVRInput.Controller.LTouch);

            euler.y += thumbStickState.x * rotateInfluence;
            transform.rotation = Quaternion.Euler(euler);
        }
    }
}