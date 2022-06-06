using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SeperateCharacterByEffect : MonoBehaviour
{
    public enum TextLocationByLinks
    {
        Initial,
        Mid,
        Final
    }

    private TextEffectTypes textEffectTypes;
    private EffectScriptsManager effectScripts;
    private TMP_TextInfo _TextInfo;

    private TextLocationByLinks textLocation;

    private int initalChar, lastChar;
    // Start is called before the first frame update
    void Awake()
    {
        textEffectTypes = GetComponent<TextEffectTypes>();
        effectScripts = GetComponent<EffectScriptsManager>();
        DialogueManagerStates.OnStateChange += WhenToExecute;
    }
    void WhenToExecute(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                _TextInfo = effectScripts.proUGUI.textInfo;
                TextLocationUpdater();
                WhenToDetect();
                break;
        }
    }
    private void WhenToDetect()
    {
        if (!effectScripts.HasentFinishedTyping())
        {
            if (_TextInfo.linkCount > 0)
            {
                DetectActiveLinks();
                DetectGeneralCharacter();
            }
            else
            {
                initalChar = 0;
                lastChar = _TextInfo.characterCount - 1;
                AddGeneralCharacterLengths();
            }
        }
    }
    private void DetectActiveLinks()
    {
        foreach (TMP_LinkInfo _LinkInfo in _TextInfo.linkInfo)
        {
            string id = _LinkInfo.GetLinkID();
            foreach (TextEffectTypes.EffectTypeAndEffectiveness effectType in textEffectTypes.StateNEffects)
            {
                CheckStateOfLink(id, effectType, _LinkInfo);
            }
        }
    }
    private void DetectGeneralCharacter()
    {

        for (int i = 0; i < textEffectTypes.currentActiveLinks.Count; i++)
        {
            for (int y = 0; y < _TextInfo.characterCount; y++)
            {
                if (textLocation == TextLocationByLinks.Initial&&_TextInfo.linkInfo[0].linkTextfirstCharacterIndex!=0)
                {
                    initalChar = 0;
                    lastChar = textEffectTypes.currentActiveLinks[0].initialIndex - 1;
                    AddGeneralCharacterLengths();

                }
                if (textLocation == TextLocationByLinks.Mid)
                {
                    initalChar = textEffectTypes.currentActiveLinks[i].linkCharLength;
                    lastChar = textEffectTypes.currentActiveLinks[i + 1].initialIndex;
                    AddGeneralCharacterLengths();
                }
                if (textLocation == TextLocationByLinks.Final)
                {
                    initalChar = textEffectTypes.currentActiveLinks[textEffectTypes.currentActiveLinks.Count - 1].linkCharLength;
                    lastChar = _TextInfo.characterCount - 1;
                    AddGeneralCharacterLengths();
                }
            }

        }
    }
    private void AddGeneralCharacterLengths()
    {
        TextEffectTypes.TypeAndRange generalCharacters = new TextEffectTypes.TypeAndRange(
       "none",
       textEffectTypes.StateNEffects[textEffectTypes.StateNEffects.Count - 1],
       initalChar,
       lastChar);
        if (!textEffectTypes.generalCharacters.Contains(generalCharacters))
            textEffectTypes.generalCharacters.Add(generalCharacters);
    }
    private void CheckStateOfLink(string id, TextEffectTypes.EffectTypeAndEffectiveness effectType, TMP_LinkInfo _LinkInfo)
    {
        if (id.ToLower().Contains(effectType.states.ToString()))
        {
            TextEffectTypes.TypeAndRange linkTypeAndRange = new TextEffectTypes.TypeAndRange
            (
            id,
            effectType,
            _LinkInfo.linkTextfirstCharacterIndex,
            _LinkInfo.linkTextfirstCharacterIndex + _LinkInfo.linkTextLength 
            );
            if (!textEffectTypes.currentActiveLinks.Contains(linkTypeAndRange) && _LinkInfo.linkTextLength > 0)
                textEffectTypes.currentActiveLinks.Add(linkTypeAndRange);
        }
    }
    private void TextLocationUpdater()
    {
        for (int i = 0; i < textEffectTypes.currentActiveLinks.Count; i++)
        {
            if (i == 0)
            {
                textLocation = TextLocationByLinks.Initial;
            }
            if (i + 1 < textEffectTypes.currentActiveLinks.Count)
            {
                textLocation = TextLocationByLinks.Mid;
            }
            if (i == textEffectTypes.currentActiveLinks.Count - 1 && textEffectTypes.currentActiveLinks.Count > 1)
            {
                textLocation = TextLocationByLinks.Final;
            }
        }
    }
}

