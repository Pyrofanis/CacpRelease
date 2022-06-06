using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueBoxStatesManager : MonoBehaviour//attach per bubble
{
    private NpcDialogueBoxStates dialogueBox;
    private string objectsName;
    private void Awake()
    {
        dialogueBox = GetComponent<NpcDialogueBoxStates>();
        objectsName = gameObject.name;
    }
    private void Start()
    {
        DialogueManagerStates.OnStateChange += IfDialogueManagerStateChanged;
        DialogueManagerStates.OnTypeChange += ApplyStateAccordingToDialogueType;
    }

    private void IfDialogueManagerStateChanged(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.disabled:
                dialogueBox.ChangeDialogueState(NpcDialogueBoxStates.StateOfDialogue.disabled);
                break;
        }
    }
    private void ApplyStateAccordingToDialogueType(DialogueManagerStates.DialogueType dialogueType)
    {
        if (dialogueType.Equals(DialogueManagerStates.DialogueType.Both) || dialogueType.Equals(DialogueManagerStates.DialogueType.OnlyNPC))
        {
            CheckIfItIsCurrentSpeaker();
        }
        else
        {
            dialogueBox.ChangeDialogueState(NpcDialogueBoxStates.StateOfDialogue.disabled);
        }
    }
    private void CheckIfItIsCurrentSpeaker()
    {
        if (objectsName.ToLower().Contains(dialogueBox._currentChar.name.ToLower()))
        {
            dialogueBox.ChangeDialogueState(NpcDialogueBoxStates.StateOfDialogue.active);
        }
        else
        {
            dialogueBox.ChangeDialogueState(NpcDialogueBoxStates.StateOfDialogue.disabled);
        }
    }
}
