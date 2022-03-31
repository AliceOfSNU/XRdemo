using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Hands : MonoBehaviour
{
    public enum HandInputType
    {
        Left, Right
    }
    public bool showController = false;
    public HandInputType handType;
    
    GameObject _handModel;
    GameObject _controllerModel;

    void Start()
    {
        string suffix = handType == HandInputType.Left ? "_L" : "_R";
        _controllerModel = GameObject.Find("quest2_controller_model" + suffix);
        _handModel = GameObject.Find("oculus_hand_model" + suffix);

        setControllerModel(showController);
    }

    /// <summary>
    /// sets which model to display as controller.
    /// </summary>
    /// <param name="showControllerModel"></param>
    void setControllerModel(bool showControllerModel)
    {
        // get the XR controller (device-based) component
        var controller = GetComponent<XRController>();
        if (showController)
        {
            _controllerModel.SetActive(true);
            _handModel.SetActive(false);
            controller.modelPrefab = _controllerModel.transform;

        }
        else
        {
            _controllerModel.SetActive(false);
            _handModel.SetActive(true);
            controller.modelPrefab = _handModel.transform;
        }
        
    }
}
