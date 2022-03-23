using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{

    public enum InteractibleType
    {
        nothing,
        info,
        pickup,
        dialogue
    }

    [Header("Type of Interactible")]
    public InteractibleType interType;

    [Header("Simple info Message")]
    public string infoMessage;
    private Text infoText;

    public void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
    }

    public void Nothing()
    {
        Debug.LogWarning("Object " + this.gameObject.name + " has no type set.");
    }

    public void Info()
    {
        infoText.text = infoMessage;
    }
}
