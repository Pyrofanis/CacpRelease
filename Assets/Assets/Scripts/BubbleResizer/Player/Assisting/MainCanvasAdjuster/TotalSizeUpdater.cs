using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalSizeUpdater : MonoBehaviour
{
    private SelectionIndexVariables indexVariables;
    private RectTransform currentRect;
    // Start is called before the first frame update
    void Start()
    {
        indexVariables = GetComponentInParent<SelectionIndexVariables>();
        currentRect = GetComponent<RectTransform>();
        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
    }
    void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                UpdateSizes();
                break;
            case DialogueManagerStates.DialogueType.Both:
                UpdateSizes();
                break;
        }
    }

    private void UpdateSizes()
    {
        float sizeY;
        if (indexVariables.horizontalGroupRect.gameObject.activeInHierarchy)
        {
             sizeY = indexVariables.backgroundRect.sizeDelta.y + indexVariables.pointerRect.sizeDelta.y + indexVariables.horizontalGroupRect.sizeDelta.y;
        }
        else
        {
            sizeY = indexVariables.backgroundRect.sizeDelta.y + indexVariables.pointerRect.sizeDelta.y;
        }
        float sizeX = indexVariables.backgroundRect.sizeDelta.x;
        currentRect.sizeDelta =new Vector2(sizeX,sizeY);
    }
}
