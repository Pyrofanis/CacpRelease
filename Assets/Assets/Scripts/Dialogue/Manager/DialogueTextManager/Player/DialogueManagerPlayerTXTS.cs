using UnityEngine;


public class DialogueManagerPlayerTXTS : MonoBehaviour
{
    private DialogueTextManager dialogueManagerText;
    [HideInInspector]
    public string selectedAnswer;
    private void Awake()
    {

        dialogueManagerText = GetComponent<DialogueTextManager>();
        selectedAnswer = "";
        DialoguePlayerTextManagerStates.OnChangeVisibility += WhenToShowSelection;
    }
    private void WhenToShowSelection(DialoguePlayerTextManagerStates.VisibilityStates playerTextManagerStates)
    {
        switch (playerTextManagerStates)
        {
            case DialoguePlayerTextManagerStates.VisibilityStates.selected:
                DisplayNewSelections();
                break;
            case DialoguePlayerTextManagerStates.VisibilityStates.noSelection:
                DisplayTxtsNoSelected();
                break;

        }
    }
    public void DisplayTxtsNoSelected()
    {
        if (dialogueManagerText.dialogueManager.scriptableObject.playerResponseNEmotion.Count > 0)
            dialogueManagerText.dialogueManager.playersTxt.text = dialogueManagerText.dialogueManager.scriptableObject.playerResponseNEmotion[dialogueManagerText.IndexOfPlayersDialogue()].currentResponse;

    }
    public void DisplayNewSelections()
    {
        dialogueManagerText.playerDialogueStates.playersEffectScript.textToShowUp = selectedAnswer;
    }

}
