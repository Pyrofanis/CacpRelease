using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DialogueManagerInput : MonoBehaviour
{
    public static MainControllsAcrossPlatforms inputs;
    private DialoguePlayerTextManagerStates textManagerPlayerStates;
    private DialogueTXTManagerNPC textManagerNPC;
    private DialogueTextManager textManager;
    private DialogueManager dialogueManager;

    private bool isTypingBoth;
    private bool isTypingNpc;
    private bool isTypingPlayer;

    private void Awake()
    {
        Initializer();
    }
    // Start is called before the first frame update
    void Start()
    {
        SubscribeInputActionKeys();
        DialogueManagerStates.OnStateChange += InputsEnabler;
        DialogueManagerStates.OnStateChange += UpdateBooleans;
        DialogueManagerStates.OnTypeChange += EnableAndDisableActionsAccordingToDialogueType;
    }
  
    private void Initializer()
    {
        inputs = new MainControllsAcrossPlatforms();
        dialogueManager = GetComponent<DialogueManager>();
        textManager = GetComponent<DialogueTextManager>();
        textManagerPlayerStates = GetComponent<DialoguePlayerTextManagerStates>();
        textManagerNPC = GetComponent<DialogueTXTManagerNPC>();
    }
    private void SubscribeInputActionKeys()
    {
        inputs.DialogueControllsKit.ChangeDialogueLeft.performed += _ => textManager.DecreaseIndexOfDialogue();
        inputs.DialogueControllsKit.ChangeDialogueRight.performed += _ => textManager.IncreaseIndexOfDialogue();
        inputs.DialogueControllsKit.SelectionKey.performed += _ => textManager.SelectAnswer(isTypingBoth);
        inputs.DialogueOnlyNpcKit.SelectionKeyNpc.performed += _ => textManagerNPC.SkiTypeWritting(isTypingNpc);
    }
    private void InputsEnabler(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                inputs.DialogueControllsKit.Enable();
                break;
            case DialogueManagerStates.ManagerStates.disabled:
                inputs.DialogueControllsKit.Disable();
                break;
        }
    }
    private void UpdateBooleans(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                isTypingPlayer = textManagerPlayerStates.playersEffectScript.HasentFinishedTyping();
                isTypingNpc = dialogueManager._CurrentChar.effectScripts.HasentFinishedTyping();
                isTypingBoth = isTypingPlayer || isTypingNpc;
                break;
        }
    }
    private void EnableAndDisableActionsAccordingToDialogueType(DialogueManagerStates.DialogueType dialogueManagerStates)
    {
        switch (dialogueManagerStates)
        {
            case DialogueManagerStates.DialogueType.Both:
                inputs.DialogueOnlyNpcKit.Enable();
                inputs.DialogueOnlyPlayerKit.Enable();
                break;
            case DialogueManagerStates.DialogueType.OnlyNPC:
                inputs.DialogueOnlyNpcKit.Enable();
                inputs.DialogueOnlyPlayerKit.Disable();
                break;
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                inputs.DialogueOnlyNpcKit.Disable();
                inputs.DialogueOnlyPlayerKit.Enable();
                break;
        }
    }

}
