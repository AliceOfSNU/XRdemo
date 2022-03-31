using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRShoot : SimpleShoot
{

    public XRBaseInteractor socketInteractor;
    public Magazine magazineGo;
    public void AddMagazine(SelectEnterEventArgs args)
    {
        magazineGo = args.interactableObject.transform.GetComponent<Magazine>();
    }

    public void RemoveMagazine(SelectExitEventArgs args)
    {
        magazineGo = null;
    }


    public void OnActivate()
    {
        if (magazineGo && magazineGo.numberOfBullet > 0)
        {
            magazineGo.numberOfBullet--;
            gunAnimator.SetTrigger("Fire");
        }
    }
}
