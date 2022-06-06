using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(OpenAndResizeBubble),typeof(CloseAndResizeBubble),typeof(NPCDialogueBoxStatesManager))]
[RequireComponent(typeof(EffectScriptsManager))]
public class NpcDialogueBoxStates : MonoBehaviour
{
   
    public enum StateOfDialogue
    {
        active,
        disabled
    }
    [Header("Offset To Increase By Bubble")]
    [Range(0, 4)]
    public float _BackgroundOffset;
    [Header("Rate of Rescalling")]
    [Range(0, 15)]
    public float _RateOfRescaling=0.5f;

    public delegate void UpdateDialogueState(StateOfDialogue dialogueState);
    public event UpdateDialogueState OnDialogueStateChange;

    [HideInInspector]
    public ActivateAndSeperateTextBoxesAccordingToCharacter.TextNNameToUse _currentChar;


    [HideInInspector]
    public float _RateOfRescallingTakingInToAccountTheASpectRatio;

    [HideInInspector]
    public Vector3 textBoxSize;

    [HideInInspector]
    public TextMeshProUGUI _TextMeshProUGUI;

    [HideInInspector]
    public SpriteRenderer background;

    [HideInInspector]
    public RectTransform textsRect, backRect,canvasRect;

    private DialogueManager dialogue;
    private NpcStates npcStates;
    private RectTransform playersCanvRectTransf;
    

    private void Awake()
    {   
        dialogue = GameObject.FindObjectOfType<DialogueManager>();
        _TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        background = _TextMeshProUGUI.transform.parent.GetComponent<SpriteRenderer>();
        textsRect = _TextMeshProUGUI.GetComponent<RectTransform>();
        canvasRect = _TextMeshProUGUI.transform.parent.transform.parent.GetComponent<RectTransform>();
        backRect = background.GetComponent<RectTransform>();
        //npcStates = GetComponentInParent<NpcStates>();

    }
    private void Start()
    {
        textBoxSize = Vector3.one;
        GetPlayersCanvas();
        GetRateAccordingToAscpect();
        DialogueManagerStates.OnStateChange += DialogueUpdate;
    }
    private void DialogueUpdate(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                _currentChar = dialogue._CurrentChar;
                GetTextSize(_TextMeshProUGUI);
                //UpdateBubblePosition();
                UpdateCanvasSize();
                GetRateAccordingToAscpect();
                break;
        }
    }
    public void ChangeDialogueState(StateOfDialogue dialogueState)
    {
        if (OnDialogueStateChange != null)
        {
            OnDialogueStateChange(dialogueState);
        }
    }

    private void GetTextSize(TextMeshProUGUI textmeshPro)
    {
        textmeshPro.ForceMeshUpdate();
        textBoxSize = textmeshPro.GetRenderedValues();
    }
    private void GetRateAccordingToAscpect()
    {
        _RateOfRescallingTakingInToAccountTheASpectRatio = Camera.main.aspect * _RateOfRescaling;
    }
    public void SetChildAndParentActive(GameObject gameObjectToApplyTo, bool isItActive)
    {
        gameObjectToApplyTo.SetActive(isItActive);
        gameObjectToApplyTo.transform.parent.gameObject.SetActive(isItActive);
    }
    private void UpdateBubblePosition()
    {
        float modifierX = (canvasRect.sizeDelta.x * canvasRect.localScale.x)/2;
        float newXpOS = npcStates.transform.position.x + modifierX;
        float modifierY = (canvasRect.sizeDelta.y * canvasRect.localScale.x);
        float newYpOS = npcStates.transform.position.y/2 + modifierY+playersCanvRectTransf.sizeDelta.y*playersCanvRectTransf.lossyScale.y/8;
        canvasRect.transform.position =new Vector2(newXpOS, newYpOS);
    }
    private void GetPlayersCanvas()
    {
        VerticalLayoutGroup playersCanvas = dialogue.playersTxt.GetComponentInParent<VerticalLayoutGroup>();
        playersCanvRectTransf = playersCanvas.GetComponent<RectTransform>();
    }
    private void UpdateCanvasSize()
    {
        canvasRect.sizeDelta = background.size;
    }
   
}
