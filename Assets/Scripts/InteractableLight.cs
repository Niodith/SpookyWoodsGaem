using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour, IInteractable
{
    public GameObject LightObject;
    public void Interact()
    {
        LightObject.SetActive(!LightObject.activeSelf);
    }

    public bool IsInteractable()
    {
        return true;
    }
     
}
