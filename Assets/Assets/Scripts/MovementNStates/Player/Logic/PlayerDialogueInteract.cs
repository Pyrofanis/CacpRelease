using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueInteract : MonoBehaviour
{
    private bool canCheck;
    private GameObject npcToInteract;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
        PlayerMoveState.inputActions.MovementAndInteractionsKit.InteractionKey.performed += _ => InteractWithNpc(canCheck);
    }
    ///2D INTERACTIONS//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DialogueHolder>() != null)
        {
            canCheck = true;
            npcToInteract = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DialogueHolder>()!=null)
        {
            canCheck = true;
            npcToInteract = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DialogueHolder>() != null)
        {
            canCheck = false;
            npcToInteract = null;
        }
    }
    ///2D INTERACTIONS//

    //3D INTERACTIONS//
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<DialogueHolder>() != null)
        {
            canCheck = true;
            npcToInteract = collision.gameObject;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<DialogueHolder>() != null)
        {
            canCheck = true;
            npcToInteract = collision.gameObject;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<DialogueHolder>() != null)
        {
            canCheck = false;
            npcToInteract = null;
        }
    }
//3D INTERACTIONS//

    private void InteractWithNpc(bool canUCheck)
    {
        switch (canUCheck)
        {
            case true:
                DialogueHolder npcDialogue = npcToInteract.GetComponent<DialogueHolder>();
                if (npcDialogue != null &&dialogueManager.scriptableObject==null)
                {
                    dialogueManager.scriptableObject = npcDialogue.dialogueToInitiate;
                    npcDialogue.dialogueToInitiate = null;
                }
                break;
        }
    }
}
