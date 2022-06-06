using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBoxStateManager : MonoBehaviour
{
    private void Start()
    {
        DialogueManagerStates.OnStateChange += DetermineStateByDialogueManagerStates;
        DialogueManagerStates.OnTypeChange += DetermineStateByDialogueType;
        PlayersBoxStates.inputs.DialogueOnlyPlayerKit.SelectionKeyPlayer.performed += _ => ChangeStateOnSelection();
    }
    private void DetermineStateByDialogueManagerStates(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.disabled:
                PlayersBoxStates.ChangeDialogueState(PlayersBoxStates.PlayersDialogueStates.disabled);
                break;
        }
    }
    private void DetermineStateByDialogueType(DialogueManagerStates.DialogueType type)
    {
        switch (type)
        {
            case DialogueManagerStates.DialogueType.Both:
                PlayersBoxStates.ChangeDialogueState(PlayersBoxStates.PlayersDialogueStates.active);
                break;
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                PlayersBoxStates.ChangeDialogueState(PlayersBoxStates.PlayersDialogueStates.active);
                break;
            case DialogueManagerStates.DialogueType.OnlyNPC:
                PlayersBoxStates.ChangeDialogueState(PlayersBoxStates.PlayersDialogueStates.disabled);
                break;


        }

    }
    public void ChangeStateOnSelection()
    {
        PlayersBoxStates.ChangeDialogueState(PlayersBoxStates.PlayersDialogueStates.selected);
    }
}
