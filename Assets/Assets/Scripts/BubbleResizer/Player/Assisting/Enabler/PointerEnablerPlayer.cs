using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEnablerPlayer : MonoBehaviour
{
    private SpriteRenderer pointerSprite;

    // Start is called before the first frame update
    void Start()
    {
        pointerSprite = GetComponent<SpriteRenderer>();

        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
        DialogueManagerStates.OnStateChange += DialogueUpdate;
    }

    void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                pointerSprite.enabled = true;
                break;
            case DialogueManagerStates.DialogueType.Both:
                pointerSprite.enabled = true;
                break;
            case DialogueManagerStates.DialogueType.OnlyNPC:
                pointerSprite.enabled = false;
                break;
        }
    }
    void DialogueUpdate(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.disabled:
                pointerSprite.enabled = false;
                break;
        }
    }

}
