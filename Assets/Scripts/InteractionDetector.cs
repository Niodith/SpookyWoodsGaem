using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private List<IInteractable> interactables= new List<IInteractable>();


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) &&interactables.Count>0)
        {
            foreach(IInteractable i in interactables)
            {
                i.Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<IInteractable>();
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
