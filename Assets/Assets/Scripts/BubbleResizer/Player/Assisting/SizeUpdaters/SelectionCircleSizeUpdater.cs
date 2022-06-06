using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCircleSizeUpdater : MonoBehaviour
{
    private SpriteRenderer circleSprite;
    private RectTransform circleRect;
    // Start is called before the first frame update
    void Start()
    {
        circleSprite = GetComponent<SpriteRenderer>();
        circleRect = GetComponent<RectTransform>();
        DialogueManagerStates.OnTypeChange += DialogueTypeUpdate;
    }
    void DialogueTypeUpdate(DialogueManagerStates.DialogueType dialogueType)
    {
        switch (dialogueType)
        {
            case DialogueManagerStates.DialogueType.OnlyPlayer:
                UpdateSize();
                break;
            case DialogueManagerStates.DialogueType.Both:
                UpdateSize();
                break;
        }
    }
    private void UpdateSize()
    {
            float numberOfObjectInCurrentGroup = DialogueManager.currentSOStatic.playerResponseNEmotion.Count*2 + 3;
            float size = PlayersBoxStates.background.size.x / numberOfObjectInCurrentGroup;
            circleSprite.size = Vector2.one * size;
            circleRect.sizeDelta = circleSprite.size;
    }
}
