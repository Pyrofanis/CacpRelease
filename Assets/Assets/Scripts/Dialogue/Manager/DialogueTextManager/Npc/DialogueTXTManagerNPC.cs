using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTXTManagerNPC : MonoBehaviour
{
    private DialogueTextManager textManager;
    // Start is called before the first frame update
    void Start()
    {
        textManager = GetComponent<DialogueTextManager>();
        DialogueManagerStates.OnTypeChange += WhenToApplyNpcesTXTS;
    }
    private void WhenToApplyNpcesTXTS(DialogueManagerStates.DialogueType type)
    {
        switch (type)
        {
            case DialogueManagerStates.DialogueType.OnlyNPC:
                textManager.dialogueManager._CurrentChar.effectScripts.textToShowUp = textManager.dialogueManager.scriptableObject.Npcresponse;
                break;
            case DialogueManagerStates.DialogueType.Both:
                textManager.dialogueManager._CurrentChar.effectScripts.textToShowUp = textManager.dialogueManager.scriptableObject.Npcresponse;
                break;
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                textManager.dialogueManager._CurrentChar.effectScripts.textToShowUp = "";
                break;
        }
    }
    public void SkiTypeWritting(bool @isTyping )
    {
        if (isTyping) textManager.dialogueManager._CurrentChar.effectScripts.characterIndex = textManager.dialogueManager._CurrentChar.effectScripts.textToShowUp.Length - 1;
    }

}
