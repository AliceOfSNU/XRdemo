using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorGrabbable : MonoBehaviour
{
    Material mat;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    public void OnHover()
    {
        mat.color = Color.black;
    }
    public void OnHoverEnd()
    {
        mat.color = Color.blue;
    }

    public void OnGrab()
    {
        mat.color = Color.red;
    }

    public void OnRelease()
    {
        mat.color = Color.blue;
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
    }
}
