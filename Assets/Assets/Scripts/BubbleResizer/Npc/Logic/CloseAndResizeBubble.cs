using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CloseAndResizeBubble : MonoBehaviour
{
    private NpcDialogueBoxStates dialogueBoxResizer;

    private Vector3 maxSize;
    private void Awake()
    {
        dialogueBoxResizer = GetComponent<NpcDialogueBoxStates>();

    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueBoxResizer.OnDialogueStateChange += ApplyIfActive;
        maxSize = dialogueBoxResizer.background.size;
    }
    private void ApplyIfActive(NpcDialogueBoxStates.StateOfDialogue dialogueState)
    {
        switch (dialogueState)
        {
            case NpcDialogueBoxStates.StateOfDialogue.active:
                maxSize = dialogueBoxResizer.background.size;
                break;
            case NpcDialogueBoxStates.StateOfDialogue.disabled:
                ResizingEffect();
                WhenToCloseBubble();
                break;
        }
    }
    private void WhenToCloseBubble()
    {
            dialogueBoxResizer._TextMeshProUGUI.enabled = false;
            dialogueBoxResizer.background.enabled = false;
    }

    private Vector3 CalculatedComponenetsScale()
    {
        return (maxSize / 2) / dialogueBoxResizer.background.size;
    }
    private void ResizingEffect()
    {
        dialogueBoxResizer.background.size = Vector3.Lerp(dialogueBoxResizer.background.size, maxSize / 2, Time.deltaTime * dialogueBoxResizer._RateOfRescallingTakingInToAccountTheASpectRatio);
        dialogueBoxResizer.textsRect.localScale = CalculatedComponenetsScale();
        dialogueBoxResizer.backRect.localScale = CalculatedComponenetsScale();
    }

}
