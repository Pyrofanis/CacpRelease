using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenAndResizeBubble : MonoBehaviour
{
    private NpcDialogueBoxStates dialogueBoxResizer;
    private Vector3 _WantedRess;

    // Start is called before the first frame update
    private void Start()
    {
        dialogueBoxResizer = GetComponent<NpcDialogueBoxStates>();

        dialogueBoxResizer.OnDialogueStateChange += ApplyIfActive;
    }
    private void ApplyIfActive(NpcDialogueBoxStates.StateOfDialogue dialogueState)
    {
        switch (dialogueState)
        {
            case NpcDialogueBoxStates.StateOfDialogue.active:
                EnableComponentsOnNeed();
                ResizingEffect();
                break;
        }
    }
    private void EnableComponentsOnNeed()
    {
        dialogueBoxResizer.background.enabled = true;
        dialogueBoxResizer._TextMeshProUGUI.enabled = true;
    }
    private void CalculateWantedResolution()
    {   if (dialogueBoxResizer.textBoxSize.x > 0)
        {
           float sizeX= dialogueBoxResizer.textBoxSize.x + dialogueBoxResizer.textBoxSize.x * dialogueBoxResizer._BackgroundOffset/2;
            float sizeY= dialogueBoxResizer.textBoxSize.y + dialogueBoxResizer.textBoxSize.y * dialogueBoxResizer._BackgroundOffset;
            _WantedRess = new Vector3(sizeX, sizeY);
        }
    }
    private Vector3 CalculatedComponentsScale()
    {   
        if (_WantedRess.magnitude >= dialogueBoxResizer.background.size.magnitude)
        {   
            float xValue=Mathf.Clamp01(dialogueBoxResizer.background.size.x / _WantedRess.x);
            float yValue= Mathf.Clamp01(dialogueBoxResizer.background.size.y / _WantedRess.y); 
            return new Vector3(xValue,yValue,0);
        }
        else
        {
            float xValue = Mathf.Clamp01(_WantedRess.x/dialogueBoxResizer.background.size.x );
            float yValue = Mathf.Clamp01(_WantedRess.y/dialogueBoxResizer.background.size.y);
            return new Vector3(xValue, yValue,0);
        }
    }
    private void ResizingEffect()
    {   
        CalculateWantedResolution();
        dialogueBoxResizer.background.size = Vector3.Lerp(dialogueBoxResizer.background.size, _WantedRess, Time.deltaTime * dialogueBoxResizer._RateOfRescallingTakingInToAccountTheASpectRatio);
        dialogueBoxResizer.textsRect.localScale = CalculatedComponentsScale();
        dialogueBoxResizer.backRect.localScale = CalculatedComponentsScale();
    }


}
