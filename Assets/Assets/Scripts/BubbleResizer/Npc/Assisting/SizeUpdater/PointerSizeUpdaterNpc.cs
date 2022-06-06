using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointerSizeUpdaterNpc : MonoBehaviour
{
    private NpcDialogueBoxStates npcDialogue;
    private SpriteRenderer pointerSprite;
    private RectTransform rectTransform;
    void Start()
    {
        npcDialogue = transform.parent.GetComponentInChildren<NpcDialogueBoxStates>();
        rectTransform = GetComponent<RectTransform>();
        pointerSprite = GetComponent<SpriteRenderer>();
     
    }
    private void Update()
    {
        UpdateSizeOfPointer();
    }
    private void UpdateSizeOfPointer()
    {
        float sizeX = npcDialogue.background.size.y / 4;
        float sizeY = npcDialogue.background.size.y / 4;
        pointerSprite.size = new Vector2(sizeX, sizeY);
        rectTransform.sizeDelta = pointerSprite.size;
    }
}
