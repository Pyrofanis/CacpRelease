using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSizeUpdaterPlayer : MonoBehaviour
{
    private SpriteRenderer pointerSprite;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        pointerSprite = GetComponent<SpriteRenderer>();
        rectTransform = GetComponent<RectTransform>();
        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
    }

    void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                UpdatePointerSize();
                break;
            case DialogueManagerStates.DialogueType.Both:
                UpdatePointerSize();
                break;
          
        }
    }

    private void UpdatePointerSize()
    {
        float sizeX = PlayersBoxStates.background.size.y / 2;
        float sizeY = PlayersBoxStates.background.size.y / 2;
        pointerSprite.size = new Vector2(sizeX, sizeY);
        rectTransform.sizeDelta = pointerSprite.size;
    }
}
