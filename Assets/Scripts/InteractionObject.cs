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

    [Header("Dialogue Messages")]
    public string[] dialogue;
    private Text dialogueText;

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
        StartCoroutine(ShowInfo(infoMessage, 2.5f));
    }

    public void Pickup()
    {
        Debug.Log("Picked Up!");
        this.gameObject.SetActive(false);
    }
    public void Dialogue()
    {
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
}
