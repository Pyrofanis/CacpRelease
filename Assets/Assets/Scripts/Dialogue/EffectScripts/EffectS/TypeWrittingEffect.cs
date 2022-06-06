using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class TypeWrittingEffect : MonoBehaviour
{
   
    private EffectScriptsManager effectsScriptManager;
    private float timer;
    private char[] currentTXTChars;
    // Start is called before the first frame update
    void Start()
    {
        effectsScriptManager = GetComponent<EffectScriptsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (effectsScriptManager.proUGUI.enabled)
        {
            case true:
                currentTXTChars= effectsScriptManager.textToShowUp.ToCharArray();
                if ( effectsScriptManager.characterIndex <currentTXTChars.Length )
                {
                    CheckIfEncounteredLinkAndActAccordingly();
                }
                break;
        }
    }
    private void CheckIfEncounteredLinkAndActAccordingly()
    {
        if (currentTXTChars[effectsScriptManager.characterIndex].Equals('<'))
        {
            SkipIfTag();
        }
        else
        {
            TypeWritting(effectsScriptManager.HasentFinishedTyping());
        }
    }
    private void TypeWritting(bool canYouUseDat)
    {
        if (timer>=0)
        timer -= Time.deltaTime;
        while (timer < 0&& canYouUseDat)
        {
            
            timer += effectsScriptManager.timerOfTypeWrittingEffect;
            effectsScriptManager.characterIndex++;
            effectsScriptManager.proUGUI.text = effectsScriptManager.textToShowUp.Substring(0, effectsScriptManager.characterIndex);
        }
        
    }
    private void SkipIfTag()
    {
      
            while (!currentTXTChars[effectsScriptManager.characterIndex+1].Equals('>'))
            {
                effectsScriptManager.characterIndex++;
            }
      
    }


}
