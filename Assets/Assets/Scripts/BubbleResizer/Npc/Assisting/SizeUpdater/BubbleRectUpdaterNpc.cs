using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleRectUpdaterNpc : MonoBehaviour
{
    private RectTransform rectTransform;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
    }

    private void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.Both:
                UpdateSize();
                break;
            case DialogueManagerStates.DialogueType.OnlyNPC:
                UpdateSize();
                break;
        }
    }
    private void UpdateSize()
    {
        rectTransform.sizeDelta = spriteRenderer.size;
    }
}
