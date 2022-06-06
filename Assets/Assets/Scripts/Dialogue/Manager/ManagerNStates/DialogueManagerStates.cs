using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerStates : MonoBehaviour
{
    public enum ManagerStates
    {
        active,
        disabled
    }

    public enum DialogueType
    {
        OnlyNPC,
        OnlyPlayer,
        Both
    }

    public delegate void StateChange(ManagerStates managerStates);
    public static event StateChange OnStateChange;

    public delegate void TypeChange(DialogueType dialogueType);
    public static event TypeChange OnTypeChange;

    public static DialogueType curretDialogueType;
    public static void ChangeState(ManagerStates managerStates)
    { 
        if (OnStateChange != null)
        {
            OnStateChange(managerStates);
        }
    }   
    public static void ChangeDialogueType(DialogueType dialogueType)
    {
        if (OnTypeChange != null)
        {
            curretDialogueType = dialogueType;
            OnTypeChange(dialogueType);
        }
    }

}
