using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRectUpdater : MonoBehaviour
{
    private RectTransform txtRect;
    private RectTransform pointerRect;
    private RectTransform canvasRect;
    // Start is called before the first frame update
    void Start()
    {
        canvasRect = GetComponent<RectTransform>();
        txtRect = GetComponentInChildren<BubbleRectUpdaterNpc>().GetComponent<RectTransform>();
        pointerRect = GetComponentInChildren<PointerEnablerNpc>().GetComponent<RectTransform>();
        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
    }
    void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.Both:
                ResizeRect();
                break;
            case DialogueManagerStates.DialogueType.OnlyNPC:
                ResizeRect();
                break;
        }

    }
    private void ResizeRect()
    {
        float sizeX = txtRect.sizeDelta.x;
        float sizeY = txtRect.sizeDelta.y + pointerRect.sizeDelta.y;
        canvasRect.sizeDelta =new Vector2(sizeX,sizeY);
    }
}
