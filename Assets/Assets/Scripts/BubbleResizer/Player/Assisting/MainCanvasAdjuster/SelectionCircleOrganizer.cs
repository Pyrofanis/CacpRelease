using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCircleOrganizer : MonoBehaviour
{
    [Header("Selected Sprite")]
    public Sprite SelectedIndex;
    [Header("Unselected Sprite")]
    public Sprite UnselectedIndex;

    [Header("Selection Prefab")]
    public GameObject selectionIndexPrefab;

    [HideInInspector]
    public List<GameObject> currentSelectionIndexes;

    private SelectionIndexVariables indexVariables;
    void Awake()
    {
        indexVariables = GetComponentInParent<SelectionIndexVariables>();

    }
    // Start is called before the first frame update
    private void Start()
    {
        currentSelectionIndexes.Add(indexVariables.circleUpdRect.gameObject);
        DialogueManagerStates.OnStateChange += DialogueUpdater;
    }
    private void DialogueUpdater(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                ManageNumberOfCircles();
                break;
        }

    }
    private void ManageNumberOfCircles()
    {
        if (currentSelectionIndexes.Count < DialogueManager.currentSOStatic.playerResponseNEmotion.Count)//adds indexes if less than current instantiated responses
        {
            currentSelectionIndexes.Add(Instantiate(selectionIndexPrefab, transform));
        }
        else
        {
            LogicApply();
        }
    }
    private void LogicApply()
    {
        for (int i = 0; i < currentSelectionIndexes.Count; i++)
        {
            SpriteRenderer currentSprite = currentSelectionIndexes[i].GetComponent<SpriteRenderer>();
            if (PlayersBoxStates.background.enabled)
            {
                DisableExtraNEnableIfNeeded(i, currentSelectionIndexes[i]);
                ChangeBettweenSprites(i, currentSprite);
            }
            else
            {
                currentSelectionIndexes[i].SetActive(false);
            }

        }
    }
    private void EnableExtra(GameObject currentObject)
    {
        if (!currentObject.activeSelf)
        {
            currentObject.SetActive(true);
        }
    }
    private void DisableExtraNEnableIfNeeded(int index, GameObject currentObject)
    {
        if (index > DialogueManager.currentSOStatic.playerResponseNEmotion.Count - 1)
        {
            currentObject.SetActive(false);
        }
        else
        {
            EnableExtra(currentObject);
        }
    }
    private void ChangeBettweenSprites(int index, SpriteRenderer currentSprite)
    {
        if (indexVariables.textManager.index.Equals(index))
        {
            currentSprite.sprite = SelectedIndex;
        }
        else
        {
            currentSprite.sprite = UnselectedIndex;
        }
    }

}
