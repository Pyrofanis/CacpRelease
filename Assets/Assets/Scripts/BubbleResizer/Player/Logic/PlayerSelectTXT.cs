using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectTXT : MonoBehaviour
{
    private Vector2 _MinimumScale, _MaximumScale;
    // Start is called before the first frame update
    void Start()
    {
        PlayersBoxStates.OnDialogueChangeStatePlayer += WhatToDoWhenSelectedObject;
        CalculateValues();
    }
    private void WhatToDoWhenSelectedObject(PlayersBoxStates.PlayersDialogueStates playersDialogueStates)
    {
        switch (playersDialogueStates)
        {
            case PlayersBoxStates.PlayersDialogueStates.selected:
                SmallAnimationTrigger();
                break;
        }
    }
    private void SmallAnimationTrigger()
    {

        PlayersBoxStates.background.size = Vector2.Scale(PlayersBoxStates.background.size, TargetVector());
        PlayersBoxStates.text.rectTransform.localScale = TextsScale();
    }
    private Vector3 TargetVector()
    {
        float effectX = Mathf.PerlinNoise(_MinimumScale.x, _MaximumScale.x)*2;
        float effectY = Mathf.PerlinNoise(_MinimumScale.y, _MaximumScale.y)*2;
        Vector2 targetVector = new Vector2(effectX, effectY);
        return targetVector;
    }
    private Vector3 TextsScale()
    {
        return Vector3.Lerp(PlayersBoxStates.text.rectTransform.localScale, Vector3.zero, Time.deltaTime * PlayersBoxStates._RateOfIncrementSet);
    }
    private void CalculateValues()
    {
        _MaximumScale = PlayersBoxStates.background.size;
        _MinimumScale = _MaximumScale / 4;
    }
}
