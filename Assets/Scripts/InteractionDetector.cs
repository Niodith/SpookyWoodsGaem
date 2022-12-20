using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private List<IInteractable> interactables= new List<IInteractable>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) &&interactables.Count>0)
        {
            foreach(IInteractable i in interactables)
            {
                i.Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        var newInteractable = other.GetComponent<IInteractable>();
        if (newInteractable != null)
        {
            interactables.Add(newInteractable);
            newInteractable.Interact(); //remove this later once you dont want to instantly interact with anything on sight.
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var newInteractable = other.GetComponent<IInteractable>();
        interactables.Remove(newInteractable);
    }
}
