using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSimple : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text whoTalkingText;
    [SerializeField]private string[] sentences;
    [SerializeField] private string[] speaker;
    public GameObject hideCanvas; // что бы на время диалога убирать ui мяса и всего такого
    public GameObject dialogueCamera;
    public GameObject dialogueCanvas;
    public bool isEnded = false;
    public int i;
    public void NextButton()
    {
        i++;
        if(i == 2) 
        {
            EndDialogue();
            i = 0;
        }
        dialogueText.text = sentences[i];
        whoTalkingText.text = speaker[i];
    }
    public void StartDialogue()
    {
        Player.canmove = false;
        dialogueCanvas.SetActive(true);
        dialogueCamera.SetActive(true);
        hideCanvas.SetActive(false);
        whoTalkingText.text = speaker[0];
        dialogueText.text = sentences[0];
    }
    public void EndDialogue()
    {
        Player.canmove = true;
        isEnded = true;
        dialogueCanvas.SetActive(false);
        dialogueCamera.SetActive(false);
        hideCanvas.SetActive(true);
    }
}
