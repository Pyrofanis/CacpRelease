using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueBox", menuName = "DialogueSystem/DialogueBox", order = 0)]
public class DialogueScriptableObject : ScriptableObject
{
    [Header("Previous Scriptable Object")]
    [Tooltip("It is used only to save time for the developers that are going to use this tool not applied in any script")]
    public DialogueScriptableObject previouScriptableObject;

    [Header("Current Speaker")]
    public DialogueManager.CharacterBubble _CurrentNpcSpeaker;
   
    [Header("Npc Dialogue Box")]
    [Tooltip("What The Npc Will Say")]
    [TextArea]
    public string Npcresponse;

    [Header("Npc Emotion")]
    [Tooltip("Emotion Facial animation to play")]
    public NpcStates.Emotions currentEmotion;


    [Header("Players Responses")]
    [Tooltip("Emotion Facial animation to play N Text 2 say")]
    public List<PlayerStates.ResponseAndEmotion> playerResponseNEmotion;
    [Min(1)]
    public List<DialogueScriptableObject> _DialogueToRedirectTo;

    [Header("New Name Of Dialogue Box")]
    [Header("Rename Dialogue Box")]
    public string newNameOfDialogueBox;




}
