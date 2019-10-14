using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    /* INSTRUCTIONS FOR USE:
     * you must complete the following two steps in order to subscribe to
     * event triggers when one of the buttons is pressed.
     * 
     * 1. in the Start function of the script you are creating, subscribe a
     * function that you want to be triggered by a button press to that buttons
     * corresponding event. For example: to subscribe a function to be activated
     * when the button x is pressed, you would include 
     * InputSystem.onXButtonPressed += functionName;. This would subscribe the 
     * function "FunctionName" to the event onXButtonPressed. One thing to note 
     * is that all functions that you  subscribe to the events must have the return
     * type of null and take in no inputs, as this is the signature for the delgates
     * for the events.
     * 
     * 2. To ensure that the triggers continue to work scene to scene. We have 
     * to unsubscribe our functions from the triggers when we leave a scene to
     * ensure that we dont try to activate a function on a now non-existant  
     * object. We can do this by adding the OnDisable() function to each script
     * that subscribes to an event. inside OnDisable, we can unsubscribe any function
     * by doing the following:
     * 
     *  void OnDisable()
     *      {
     *          Debug.Log("PrintOnDisable: "+ this.name +" was disabled");
     *          InputSystem.onXButtonPressed -= FunctionName;
     *      }
     * 
     */
    
    #region Singleton
    private static InputSystem _instance;
    public static InputSystem Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    #region LeftHandEvents
    // left  hand button events
    public delegate void XButtonPressed();
    public static event XButtonPressed onXButtonPressed;

    public delegate void YButtonPressed();
    public static event YButtonPressed onYButtonPressed;

    public delegate void LeftIndexTriggerPressed();
    public static event LeftIndexTriggerPressed onLeftIndexTriggerPressed;

    public delegate void LeftHandTriggerPressed();
    public static event LeftHandTriggerPressed onLeftHandTriggerPressed;
    #endregion

    #region RightHandEvents
    // right hand button events
    public delegate void AButtonPressed();
    public static event AButtonPressed onAButtonPressed;

    public delegate void BButtonPressed();
    public static event BButtonPressed onBButtonPressed;

    public delegate void RightIndexTriggerPressed();
    public static event RightIndexTriggerPressed onRightIndexTriggerPressed;

    public delegate void RightHandTriggerPressed();
    public static event RightHandTriggerPressed onRightHandTriggerPressed;
    #endregion

    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        #region RightHandActions
        // if X is pressed
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            onXButtonPressed();
        }

        // if Y is pressed
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            onYButtonPressed();
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            onLeftIndexTriggerPressed();
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            onLeftHandTriggerPressed();
        }
        #endregion

        #region LeftHandActions 
        // if A is pressed
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            onAButtonPressed();
        }

        // if B is pressed
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            onBButtonPressed();
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            onRightIndexTriggerPressed();
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            onRightHandTriggerPressed();
        }
        #endregion
    }
}
