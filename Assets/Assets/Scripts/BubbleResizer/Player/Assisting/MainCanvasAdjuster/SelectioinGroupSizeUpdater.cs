using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectioinGroupSizeUpdater : MonoBehaviour
{

    private SelectionIndexVariables indexVariables;
    private SpriteRenderer groupsSprite;
    private RectTransform selectionGroupRect;
    // Start is called before the first frame update
    void Start()
    {
        indexVariables = GetComponentInParent<SelectionIndexVariables>();
        groupsSprite = GetComponent<SpriteRenderer>();
        selectionGroupRect = GetComponent<RectTransform>();
        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
    }
    void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                groupsSprite.enabled = true;
                UpdateSize();
                break;
            case DialogueManagerStates.DialogueType.Both:
                groupsSprite.enabled = true;
                UpdateSize();
                break;

        }
    }

    private void UpdateSize()
    {
        float sizeX = indexVariables.backgroundRect.sizeDelta.x;
        float sizeY = indexVariables.arrowRect.sizeDelta.y * 1.2f;
        groupsSprite.size = new Vector2(sizeX, sizeY);
        selectionGroupRect.sizeDelta = groupsSprite.size;
    }
}
