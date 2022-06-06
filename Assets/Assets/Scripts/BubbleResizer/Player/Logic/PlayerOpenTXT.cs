using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenTXT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayersBoxStates.OnDialogueChangeStatePlayer += InCaseItIsActive;
    }
    private void InCaseItIsActive(PlayersBoxStates.PlayersDialogueStates playersDialogueStates)
    {
        switch (playersDialogueStates)
        {
            case PlayersBoxStates.PlayersDialogueStates.active:
                EnableWantedComponenets();
                ResizeWithEffect();
                break;
        }
    }

    private void ResizeWithEffect()
    {
        PlayersBoxStates.background.size = Vector3.Lerp(PlayersBoxStates.background.size, MaxSize(), Time.deltaTime * PlayersBoxStates._RateOfIncrementSet);
        float scaleX = Mathf.Clamp01(PlayersBoxStates.background.size.x / MaxSize().x);
        float scaleY = Mathf.Clamp01(PlayersBoxStates.background.size.y / MaxSize().y);
        Vector3 diviation =new Vector2(scaleX,scaleY) ;
        PlayersBoxStates.text.rectTransform.localScale = diviation;
    }
    private void EnableWantedComponenets()
    {
        PlayersBoxStates.background.enabled = true;
        PlayersBoxStates.text.enabled = true;
    }
    private Vector3 MaxSize()
    {
        float sizeX= PlayersBoxStates._TextResolution.x + PlayersBoxStates._TextResolution.x * PlayersBoxStates._MaximumBackgroundIncrement/2;
        float sizeY= PlayersBoxStates._TextResolution.y + PlayersBoxStates._TextResolution.y * PlayersBoxStates._MaximumBackgroundIncrement;
        Vector3 calculatedMaxSize =new Vector2(sizeX,sizeY);
        if (calculatedMaxSize.x <= 0)
        {
            return PlayersBoxStates.background.size;
        }
        else if (calculatedMaxSize.x < PlayersBoxStates._MinimumBackSize)
        {
            return new Vector3(PlayersBoxStates._MinimumBackSize, calculatedMaxSize.y);
        }
        else
        {
            return calculatedMaxSize;
        }
    }
}
