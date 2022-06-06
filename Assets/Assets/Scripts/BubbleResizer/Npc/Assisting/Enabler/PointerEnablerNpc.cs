using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEnablerNpc : MonoBehaviour
{
    private SpriteRenderer pointerSprite;
    private NpcDialogueBoxStates npcDialogue;

    // Start is called before the first frame update
    void Start()
    {
        npcDialogue = transform.parent.GetComponentInChildren<NpcDialogueBoxStates>();
        pointerSprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        pointerSprite.enabled = npcDialogue.background.enabled;
    }

}
