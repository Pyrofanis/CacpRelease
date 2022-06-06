using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TypeWrittingEffect), typeof(EffectApplier), typeof(TextEffectTypes))]
[RequireComponent(typeof(SeperateCharacterByEffect))]
public class EffectScriptsManager : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI proUGUI;
    [HideInInspector]
    public int characterIndex = 0;

    [Header("verticles vector in y axes")]
    [Header("the effect intensity in x,y verticles of text")]
    [Tooltip("the intensity of the verticles vector in y axes")]
    [Range(0, 100)]
    public float yEffectIntensity;
    [Header("verticles vector in x axes")]
    [Tooltip("the intensity of the verticles vector in x axes")]
    [Range(0, 100)]
    public float xEffectIntensity;

    [Header("Typing Speed")]
    [Tooltip("its a timer")]
    [Range(0, 1)]
    public float timerOfTypeWrittingEffect;
    [HideInInspector]
    public string textToShowUp;

    private TextEffectTypes textEffectTypes;
    private void Awake()
    {
        proUGUI = GetComponent<TextMeshProUGUI>();
        textEffectTypes = GetComponent<TextEffectTypes>();
    }
    private void Start()
    {
        DialogueManagerInput.inputs.DialogueControllsKit.SelectionKey.performed += _ => ResetStringCharacterIndex();
        DialogueManagerInput.inputs.DialogueControllsKit.SelectionKey.performed += _ => ResetGeneralCharactersLists();

    }
    private void ResetStringCharacterIndex()
    {
        if (!HasentFinishedTyping())
            characterIndex = 0;
    }
    private void ResetGeneralCharactersLists()
    {
        textEffectTypes.generalCharacters.Clear();
        textEffectTypes.currentActiveLinks.Clear();
    }
    public bool HasentFinishedTyping()//used in typewritting
    {
        if (characterIndex <= textToShowUp.Length - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Vector2 TrembleAndWomble(float time, float xIntensity, float yIntensity)//used in effect scripts
    {
        return new Vector2(Mathf.Sin(time * xIntensity), Mathf.Cos(time * yIntensity));
    }
}
