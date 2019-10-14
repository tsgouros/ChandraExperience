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


    // Start is called before the first frame update
    void Start()
    {
        cameraRig = this.gameObject;

        playerCenterEye = GameObject.Find("CenterEyeAnchor");

    }

    // Update is called once per frame
    void Update()
    {
        //  logic for moving camera rig forward/backward with left thumb stick.
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, 
                        OVRInput.Controller.LTouch) || 
           OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, 
                        OVRInput.Controller.LTouch)){
            // The thumbstick state represented as a vector.
            Vector2 thumbStickState = 
                OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, 
                             OVRInput.Controller.LTouch);

            Vector3 faceForward = playerCenterEye.transform.forward;

            if(thumbStickState.y > 0 || thumbStickState.y < 0) { // Moving forward.
                Debug.Log("Moving...");
                cameraRig.transform.position += 
                    faceForward * movementSpeed * thumbStickState.y;
            }
        }

        //  logic for turning camera rig with right thumb stick.
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft,
                        OVRInput.Controller.RTouch) ||
            OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight,
                        OVRInput.Controller.RTouch))
        {
            // The thumbstick state represented as a vector.
            Vector2 thumbStickState =
                OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick,
                             OVRInput.Controller.RTouch);
            Vector3 lookVector = new Vector3(thumbStickState.x, 0, 0);

            Quaternion targetRotation = Quaternion.LookRotation(lookVector, Vector3.up);
            cameraRig.transform.rotation = Quaternion.Lerp(cameraRig.transform.rotation, targetRotation, Time.deltaTime);

        }


    }
}
