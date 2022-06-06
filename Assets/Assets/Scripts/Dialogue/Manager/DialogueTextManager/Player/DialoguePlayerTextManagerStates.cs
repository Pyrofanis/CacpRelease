using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueManagerPlayerTXTS))]
public class DialoguePlayerTextManagerStates : MonoBehaviour
{
    public enum VisibilityStates
    {
        selected,
        noSelection,
    }
    public static VisibilityStates currentVisibility;

    public delegate void ChangeVisibilityStates(VisibilityStates showAnswer);
    public static event ChangeVisibilityStates OnChangeVisibility;

    private DialogueTextManager textManager;

    [HideInInspector]
    public DialogueManagerPlayerTXTS playerTXTS;
    [HideInInspector]
    public EffectScriptsManager playersEffectScript;
    // Start is called before the first frame update
    void Start()
    {
        textManager = GetComponent<DialogueTextManager>();
        playerTXTS = GetComponent<DialogueManagerPlayerTXTS>();
        playersEffectScript = textManager.dialogueManager.playersTxt.GetComponent<EffectScriptsManager>();
        DialogueManagerStates.OnStateChange += StateUpdate;

    }
    private void StateUpdate(DialogueManagerStates.ManagerStates _Manager)
    {
        switch (_Manager)
        {
            case DialogueManagerStates.ManagerStates.active:
                VisibilityStatesUpdater();
                break;
        }
    }
    public static void ChangeVisibility(VisibilityStates visibilityStates)
    {
        if (OnChangeVisibility != null)
        {
            currentVisibility = visibilityStates;
            OnChangeVisibility(visibilityStates);
        }
    }
    private void VisibilityStatesUpdater()
    {
        if (playerTXTS.selectedAnswer == "")
        {
            ChangeVisibility(VisibilityStates.noSelection);
        }
        else
        {
            ChangeVisibility(VisibilityStates.selected);
        }
    }
}
