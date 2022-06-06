using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndexEnabler : MonoBehaviour
{
    public bool leftArrow;
    private SpriteRenderer currentArrow;
    private SelectionIndexVariables indexVariables;
    // Start is called before the first frame update
    void Start()
    {
        indexVariables = GetComponentInParent<SelectionIndexVariables>();
        currentArrow = GetComponent<SpriteRenderer>();
        DialogueManagerStates.OnTypeChange += WhenToRun;
        DialogueManagerStates.OnStateChange += DialogueUpdate;
    }
    private void WhenToRun(DialogueManagerStates.DialogueType DialogueType)
    {
        switch (DialogueType)
        {
            case DialogueManagerStates.DialogueType.Both:
                Enabler(!leftArrow);
                break;
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                Enabler(!leftArrow);
                break;
            case DialogueManagerStates.DialogueType.OnlyNPC:
                currentArrow.enabled = false;
                break;
        }
    }
    private void DialogueUpdate(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.disabled:
                currentArrow.enabled = false;
                break;
        }
    }
    private void Enabler(bool leftArrow)
    {
        if (indexVariables.textManager.index == 0)
        {
            currentArrow.enabled = leftArrow;
        }
       else if (indexVariables.textManager.index > 0 && indexVariables.textManager.index < DialogueManager.currentSOStatic.playerResponseNEmotion.Count - 1)
        {
            currentArrow.enabled = true;
        }
        else
        {
            currentArrow.enabled = !leftArrow;
        }
    }
}
