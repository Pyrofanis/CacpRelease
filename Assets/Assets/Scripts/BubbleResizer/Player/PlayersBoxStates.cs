using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PlayerOpenTXT),typeof(PlayerCloseTXT),typeof(PlayerSelectTXT))]
[RequireComponent(typeof(PlayersBoxStateManager),typeof(EffectScriptsManager))]
public class PlayersBoxStates : MonoBehaviour
{
    public enum PlayersDialogueStates
    {
        active,
        selected,
        disabled
    }
    public delegate void ChangeState(PlayersBoxStates.PlayersDialogueStates playersDialogueStates);
    public static event ChangeState OnDialogueChangeStatePlayer;

    [Header("percentage Increment of current TextSize ")]
    [Tooltip("it is goin to be used as value+vale*this")]
    [Range(0.1f,2)]
    public float _maximumBackgroundIncrementLocal = 1;

    [Header("animation speed ")]
    [Tooltip("it is goin to be used as Time.deltaTime*this")]
    [Range(0, 300)]
    public float _MinimumBackgroundSizeX = 150;

    [Header("animation speed ")]
    [Tooltip("it is goin to be used as Time.deltaTime*this")]
    [Range(0.1f, 5)]
    public float _RateOfIncrement = 1;

    public static float _MaximumBackgroundIncrement=1;
    public static float _RateOfIncrementSet = 1;
    public static float _MinimumBackSize;
    public static Vector3 _TextResolution;
    public static TextMeshProUGUI text;
    public static SpriteRenderer background;

    public static MainControllsAcrossPlatforms inputs;


    private RectTransform backgoundRect;
    private RectTransform currentRect;

   public static void ChangeDialogueState(PlayersDialogueStates playersDialogueState)
    {
        if (OnDialogueChangeStatePlayer != null)
        {
            OnDialogueChangeStatePlayer(playersDialogueState);
        }
    }
    private void Awake()
    {
        inputs = new MainControllsAcrossPlatforms();
        text = GetComponent<TextMeshProUGUI>();
        background = text.transform.parent.gameObject.GetComponent<SpriteRenderer>();
        backgoundRect = background.GetComponent<RectTransform>();
        GetRateOfIncrement();
    }
    private void Start()
    {
        inputs.MovementAndInteractionsKit.Enable();
        _MaximumBackgroundIncrement = _maximumBackgroundIncrementLocal;
        _MinimumBackSize = _MinimumBackgroundSizeX;
        currentRect = GetComponent<RectTransform>();
        DialogueManagerStates.OnTypeChange += DialogueType;
    }
    private void DialogueType(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.Both:
                GetResTXT();
                GetRateOfIncrement();
                UpdatebubbleRect();
                break;
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                GetResTXT();
                GetRateOfIncrement();
                UpdatebubbleRect();
                break;
        }
    }
    private void GetResTXT()
    {
        text.ForceMeshUpdate();
        _TextResolution= text.GetRenderedValues();
    }
    private void GetRateOfIncrement()
    {
        _RateOfIncrementSet = Camera.main.aspect*_RateOfIncrement;
    }
    private void UpdatebubbleRect()
    {
        currentRect.sizeDelta = background.size;
        backgoundRect.sizeDelta = background.size;
    }
   

}
