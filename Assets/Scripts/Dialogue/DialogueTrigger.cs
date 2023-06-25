using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public Message[] messages;
    public Actor[] actors;
    private int counter = -1;

    public void Interact()
    {
        if (counter <= 0)
        {
            counter++;
            StartDialogue();
        }
        if (counter >= 1)
        {
            ContinueDialogue();
        }
    }

    public void ContinueDialogue()
    {
        FindObjectOfType<DialogueManager>().NextMessage();
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }

    public void Reset()
    {
        counter = -1;
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string actorName;
    public Sprite sprite;
}
