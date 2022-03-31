using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrabInteractable : XRGrabInteractable
{

    public XRSimpleInteractable secondAttachPoint;
    XRBaseInteractor secondInteractor;

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(secondInteractor && interactorsSelecting[0]!=null)
        {
            interactorsSelecting[0].transform.GetComponent<XRBaseInteractor>().attachTransform.rotation 
                = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }
        base.ProcessInteractable(updatePhase);
    }


    public void OnSecondGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Second Grab Enter");
        secondInteractor = args.interactorObject.transform.GetComponent<XRBaseInteractor>();
    }


    public void OnSecondExit(SelectExitEventArgs args) {
        Debug.Log("Second Grab Exit");
        secondInteractor = null;
    }

    Quaternion attachInitialRotation;
    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        Debug.Log("First Grab Enter");
        attachInitialRotation = args.interactor.attachTransform.localRotation;
    }

    public void OnSelectExit(SelectExitEventArgs args)
    {
        Debug.Log("First Grab Exit");
        secondInteractor = null;
        args.interactor.attachTransform.localRotation = attachInitialRotation;
    }


    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        bool isAlreadyGrabbed = interactorsSelecting[0]!= null && !interactor.Equals(selectingInteractor);
        Debug.Log(base.IsSelectableBy(interactor) && !isAlreadyGrabbed);
        return base.IsSelectableBy(interactor) && !isAlreadyGrabbed;
    }
}
