using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public Transform interactionTransform;

    public bool clicked;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }
    public void Start()
    {

        clicked = false;
    }

    public void Update()
    {
        Transform player = PlayerController.playerController.rb.transform;
        // If we are close enough
        float distance = Vector3.Distance(player.position, interactionTransform.position);

        if (clicked == true && distance <= radius)
        {
            // Interact with the object
            Interact();

        }

    }
    private void OnDrawGizmos()
    {
        if (interactionTransform == null)
            interactionTransform = transform;


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
