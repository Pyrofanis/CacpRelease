using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialoguePlayerTextManagerStates),typeof(DialogueTXTManagerNPC))]
public class DialogueTextManager : MonoBehaviour
{
    [HideInInspector]
    public DialogueManager dialogueManager;
    [HideInInspector]
    public DialogueTXTManagerNPC managerNPC;
    [HideInInspector]
    public int index = 0;
    [HideInInspector]
    public DialoguePlayerTextManagerStates playerDialogueStates;
    private void Awake()
    {
        dialogueManager = GetComponent<DialogueManager>();
        managerNPC = GetComponent<DialogueTXTManagerNPC>();
        playerDialogueStates = GetComponent<DialoguePlayerTextManagerStates>();
    }
    public int SelectionArrayIndexer()
    {
        if (index >= 0 && index < dialogueManager.scriptableObject._DialogueToRedirectTo.Count)
        {
            return index;
        }
        else if (dialogueManager.scriptableObject._DialogueToRedirectTo.Count <= 0)
        {
            return 0;
        }
        else
        {
            return dialogueManager.scriptableObject._DialogueToRedirectTo.Count - 1;
        }
    }
    public int IndexOfPlayersDialogue()
    {
        if (index >= 0 && index < dialogueManager.scriptableObject.playerResponseNEmotion.Count)
        {
            return index;
        }
        else if (index < 0)
        {
            index = 0;
            return 0;
        }
        else 
        {
            index = dialogueManager.scriptableObject.playerResponseNEmotion.Count - 1;
            return dialogueManager.scriptableObject.playerResponseNEmotion.Count - 1;
        }
    }
    public void IncreaseIndexOfDialogue()
    {
        index++;
    }
    public void DecreaseIndexOfDialogue()
    {
        index--;
    }
    public void SelectAnswer(bool @isTyping)
    {
        if (!isTyping)
        {
            LoadScriptableObject(dialogueManager.scriptableObject._DialogueToRedirectTo[SelectionArrayIndexer()]);
        }
    }
    private void LoadScriptableObject(DialogueScriptableObject dialogue)
    {
        dialogueManager.scriptableObject = dialogue;
    }
}
