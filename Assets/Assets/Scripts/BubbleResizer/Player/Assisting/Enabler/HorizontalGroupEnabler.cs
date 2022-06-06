using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGroupEnabler : MonoBehaviour
{
    private SelectionIndexVariables indexVariables;
    // Start is called before the first frame update
    void Start()
    {
        indexVariables = GetComponent<SelectionIndexVariables>();
        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
        DialogueManagerStates.OnStateChange += DialogueUpdate;
    }
    void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                SelectionEnabler();
                break;
            case DialogueManagerStates.DialogueType.Both:
                SelectionEnabler();
                break;
            case DialogueManagerStates.DialogueType.OnlyNPC:
                indexVariables.horizontalGroupRect.gameObject.SetActive(false);
                break;
        }
    }
    void DialogueUpdate(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.disabled:
                indexVariables.horizontalGroupRect.gameObject.SetActive(false);
                break;
        }
    }
    private void SelectionEnabler()
    {
        if (DialogueManager.currentSOStatic.playerResponseNEmotion.Count > 1)
        {
            indexVariables.horizontalGroupRect.gameObject.SetActive(true);
        }
        else
        {
            indexVariables.horizontalGroupRect.gameObject.SetActive(false);
        }
    }
}
