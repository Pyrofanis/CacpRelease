using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGroupSizeUpdater : MonoBehaviour
{
    private SelectionIndexVariables indexVariables;
    void Start()
    {
        indexVariables = GetComponentInParent<SelectionIndexVariables>();

    }
    void Update()
    {
        if (DialogueManager.currentSOStatic != null && indexVariables.circleUpdRect != null)
        {
            UpdateRectSize();
        }

    }
    private void UpdateRectSize()
    {
        float size = DialogueManager.currentSOStatic.playerResponseNEmotion.Count * indexVariables.circleUpdRect.sizeDelta.x * 2;
        indexVariables.circleOrgRect.sizeDelta = size * Vector2.one;
    }
}
