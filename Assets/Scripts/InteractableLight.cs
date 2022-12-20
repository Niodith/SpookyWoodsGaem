using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour, IInteractable
{
    public GameObject LightObject;
    public bool isActive;
    public void Start()
    {
        isActive = LightObject.activeSelf;
    }
    public void Interact()
    {
        Debug.Log("Interacting with Light");
        LightObject.SetActive(!isActive);
        isActive = !isActive;
    }

    public bool IsInteractable()
    {
        return true;
    }
     
}
