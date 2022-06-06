using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateAndSeperateTextBoxesAccordingToCharacter : MonoBehaviour
{

    [Header("Npces txt box")]
    [Tooltip("Current npces text mesh pro ")]
    [HideInInspector]
    public TextMeshProUGUI[] npcesTXT;
    private DialogueManager dialogueManager;
    [System.Serializable]
    public struct TextNNameToUse
    {
        public string name;
        public TextMeshProUGUI txtOfChar;
        public EffectScriptsManager effectScripts;
        public TextNNameToUse(string newString, TextMeshProUGUI newTXT,EffectScriptsManager newEffect)
        {
            this.name = newString;
            this.txtOfChar = newTXT;
            this.effectScripts = newEffect;
        }
    }
    [Header("Active Characters Database")]
    public List<TextNNameToUse> charactersInScene;

    private void Awake()
    {   
        FindNpcesTxts();
        dialogueManager = GetComponent<DialogueManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.OnCharacterChange += AssignTXTboxPerCharacterActive;
    }
    private void FindNpcesTxts()
    {
        TextMeshProUGUI[] npcesTmpArray;
        npcesTmpArray = FindObjectsOfType<TextMeshProUGUI>(true);
        foreach (TextMeshProUGUI textMeshProUGUI in npcesTmpArray)
        {
            if (!textMeshProUGUI.name.ToLower().Contains("player") && textMeshProUGUI.name.ToLower().Contains("txt"))
            {
                TextNNameToUse textNNameTo = new TextNNameToUse(textMeshProUGUI.name, textMeshProUGUI,textMeshProUGUI.GetComponent<EffectScriptsManager>());
                charactersInScene.Add(textNNameTo);
            }
        }
    }
    private void AssignTXTboxPerCharacterActive(DialogueManager.CharacterBubble _Character)
    {

        for (int i = 0; i < charactersInScene.Count; i++)
        {
            string currentNameInStruct = charactersInScene[i].name;
            if (currentNameInStruct.ToLower().Contains(_Character.ToString().ToLower()))
            {
                dialogueManager._CurrentChar = charactersInScene[i];
            }
        }
          
    }
}
