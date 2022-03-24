using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text textBox;
    public GameObject player;
    public Animator playerAnimator;

    private Queue<string> dialogue;

    private void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);

        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;

        playerAnimator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (string currentLine in sentences)
        {
            dialogue.Enqueue(currentLine);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentLine = dialogue.Dequeue();

        textBox.text = currentLine;
        
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);

        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
