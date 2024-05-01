using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRSocketTagInteractor : XRSocketInteractor
{
    // 1
    public string targetTag;
    // Start is called before the first frame update
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && interactable.transform.tag == targetTag;
    }
public override bool CanSelect(IXRSelectInteractable interactable)
{
    XRBaseInteractable baseInteractable = interactable as XRBaseInteractable;
    if (baseInteractable != null)
    {
        return base.CanSelect(interactable) && interactable.transform.tag == targetTag && !baseInteractable.isSelected;
    }
    else
    {
        return false;
    }
}

protected override void OnSelectEntered(SelectEnterEventArgs args)
{
    base.OnSelectEntered(args);
}



}
