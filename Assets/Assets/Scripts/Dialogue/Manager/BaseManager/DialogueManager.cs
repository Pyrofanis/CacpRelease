using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(ActivateAndSeperateTextBoxesAccordingToCharacter),typeof(DialogueManagerStates))]
[RequireComponent(typeof(DialogueStatesManager),typeof(DialogueTextManager))]
public class DialogueManager : MonoBehaviour
{
    public enum CharacterBubble
    {
        npc,
        sheep,
        wolf,
        fox,
        hobogator,
    }

    [Header("Players txt box")]
    [Tooltip("Current players text mesh pro ")]
    public TextMeshProUGUI playersTxt;

    public ActivateAndSeperateTextBoxesAccordingToCharacter.TextNNameToUse _CurrentChar;

    [Header("InitialDialogueBox")]
    [Tooltip("the dialogue box that will initiate the dialogue")]
    public DialogueScriptableObject scriptableObject;
    public static DialogueScriptableObject currentSOStatic;

    public delegate void ChangeCharacterBubble(CharacterBubble character);
    public event ChangeCharacterBubble OnCharacterChange;

    [HideInInspector]
    public DialogueTextManager textManager;
    private void Awake()
    {
        textManager = GetComponent<DialogueTextManager>();
        DialogueManagerStates.OnStateChange += ChangeSpeakerWhenActive;
    }
    public void ChangeCharacter(CharacterBubble _Character)
    {
        if (OnCharacterChange != null)
        {
            OnCharacterChange(_Character);
        }
    }
    private void ChangeSpeakerWhenActive(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                ChangeCharacter(scriptableObject._CurrentNpcSpeaker);
                currentSOStatic = scriptableObject;
                break;
        }

    }
 
}
