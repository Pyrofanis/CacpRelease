using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloseTXT : MonoBehaviour
{
    private Vector3 _MinimumSize;
    // Start is called before the first frame update
    void Start()
    {
        PlayersBoxStates.OnDialogueChangeStatePlayer += InCaseItIsActive;
        CalculateNewSize();
    }
    private void InCaseItIsActive(PlayersBoxStates.PlayersDialogueStates playersDialogueStates)
    {
        switch (playersDialogueStates)
        {
            case PlayersBoxStates.PlayersDialogueStates.active:
                CalculateNewSize();
                break;
            case PlayersBoxStates.PlayersDialogueStates.disabled:
                ResizeWithEffect();
                CheckIfReachedTargetSizeAndDisable();
                break;
        }
    }
    private void CalculateNewSize()
    {
        _MinimumSize = PlayersBoxStates.background.size/2;
    }
    private void ResizeWithEffect()
    {
        PlayersBoxStates.background.size = Vector3.Lerp(PlayersBoxStates.background.size, _MinimumSize, Time.deltaTime *PlayersBoxStates._RateOfIncrementSet);
        float scaleX = Mathf.Clamp01(PlayersBoxStates.background.size.x / _MinimumSize.x);
        float scaleY = Mathf.Clamp01(PlayersBoxStates.background.size.y / _MinimumSize.y);
        Vector3 diviation = new Vector2(scaleX, scaleY);
        PlayersBoxStates.text.rectTransform.localScale = diviation;
    }
    private void CheckIfReachedTargetSizeAndDisable()
    {
        if (Mathf.Abs(PlayersBoxStates.background.size.magnitude-_MinimumSize.magnitude)<= _MinimumSize.magnitude)
        {
            DisableWantedComponenets();
        }
    }
    private void DisableWantedComponenets()
    {
        PlayersBoxStates.text.enabled = false;
        PlayersBoxStates.background.enabled = false;
    }
}
