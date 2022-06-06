using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsSizeUpdater : MonoBehaviour
{
    private SpriteRenderer arrowSprite;
    private RectTransform arrowCanvas;

    
    // Start is called before the first frame update
    void Start()
    {
        arrowSprite = GetComponent<SpriteRenderer>();
        arrowCanvas = GetComponent<RectTransform>();
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
        float numberOfObjectsInGroup = DialogueManager.currentSOStatic.playerResponseNEmotion.Count * 2 + 3;
        float newSize= PlayersBoxStates.background.size.x / numberOfObjectsInGroup;
        arrowSprite.size = newSize*Vector2.one;
        arrowCanvas.sizeDelta = arrowSprite.size;
    }
}
