using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueManager))]
public class DialogueStatesManager : MonoBehaviour
{
    private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        DialogueManagerStates.OnStateChange += DialogueTypeUpdater;
        DialoguePlayerTextManagerStates.OnChangeVisibility += TypeOfDialogueByPlayersTXTState;
    }

    // Update is called once per frame
    void Update()
    {
        DialogueActiveStateUpdater();
    }
    private void DialogueActiveStateUpdater()
    {
        if (dialogueManager.scriptableObject != null)
        {
            DialogueManagerStates.ChangeState(DialogueManagerStates.ManagerStates.active);
        }
        else
        {
            DialogueManagerStates.ChangeState(DialogueManagerStates.ManagerStates.disabled);
        }
    }
    private void DialogueTypeUpdater(DialogueManagerStates.ManagerStates _Manager)
    {
        switch (_Manager)
        {
            case DialogueManagerStates.ManagerStates.active:
                TypeOfDialogueWhileActive();
                break;
        }

    }
    private void TypeOfDialogueWhileActive()
    {
        switch (DialoguePlayerTextManagerStates.currentVisibility)
        {
            case DialoguePlayerTextManagerStates.VisibilityStates.noSelection:
                if (dialogueManager.scriptableObject.playerResponseNEmotion.Count == 0||dialogueManager._CurrentChar.effectScripts.HasentFinishedTyping())
                {
                    DialogueManagerStates.ChangeDialogueType(DialogueManagerStates.DialogueType.OnlyNPC);
                }
                else if (dialogueManager.scriptableObject.Npcresponse == ""|| dialogueManager.textManager.playerDialogueStates.playersEffectScript.HasentFinishedTyping())
                {
                    DialogueManagerStates.ChangeDialogueType(DialogueManagerStates.DialogueType.OnlyPlayer);
                }
                else
                {
                    DialogueManagerStates.ChangeDialogueType(DialogueManagerStates.DialogueType.Both);
                }
                break;
        }
    
    }
    private void TypeOfDialogueByPlayersTXTState(DialoguePlayerTextManagerStates.VisibilityStates visibility)
    {
        switch (visibility)
        {
            case DialoguePlayerTextManagerStates.VisibilityStates.selected:
                DialogueManagerStates.ChangeDialogueType(DialogueManagerStates.DialogueType.OnlyPlayer);
                break;
        }

    }
}
