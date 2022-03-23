using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public InteractionObject currentInteractObjScript = null;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInterObj != null)
        {
            CheckInteraction();
        }
    }

    void CheckInteraction()
    {
        Debug.Log("this is a " + currentInterObj.name);

        if (currentInteractObjScript.interType == InteractionObject.InteractibleType.nothing)
        {
            currentInteractObjScript.Nothing();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractibleType.info)
        {
            currentInteractObjScript.Info();
        }
    }

    private void OnTriggerStay2D(Collider2D other) //pings while in radius
    {
        if (other.gameObject.CompareTag("InterObject") == true)
        {
            currentInterObj = other.gameObject;
            currentInteractObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentInterObj = null;
        currentInteractObjScript = null;
    }



}
