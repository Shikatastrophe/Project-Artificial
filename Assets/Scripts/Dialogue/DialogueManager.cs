using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundbox;
    public Animator animator;

    Message[] currentmessages;
    Actor[] currentactors;
    int activemessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentmessages = messages;
        currentactors = actors;
        activemessage = 0;
        isActive = true; 
        Debug.Log("Loaded Messages: " + messages.Length);
        animator.SetBool("isActive", isActive);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentmessages[activemessage];
        //messageText.text = messageToDisplay.message;
        StopAllCoroutines();
        StartCoroutine(TypeMessage(messageToDisplay.message));

        Actor actorToDisplay = currentactors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.actorName;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activemessage++;
        if (activemessage < currentmessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Convo over");
            isActive = false;
            animator.SetBool("isActive", isActive);
            FindObjectOfType<DialogueTrigger>().Reset();
        }

    }


    IEnumerator TypeMessage (string message)
    {
        messageText.text = "";
        foreach(char letter in message.ToCharArray())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void Interact()
    {
        if (isActive)
        {
           // NextMessage();
        }
    }
}
