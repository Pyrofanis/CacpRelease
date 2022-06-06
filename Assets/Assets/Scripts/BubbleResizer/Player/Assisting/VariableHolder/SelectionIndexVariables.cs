using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionIndexVariables : MonoBehaviour
{
    private ArrowIndexEnabler arrowIndex;
    private SelectionCircleOrganizer circleOrganizer;
    private SelectionCircleSizeUpdater circleUpdater;
    private SelectioinGroupSizeUpdater horizontalGroup;
    private EffectScriptsManager Background;
    private PointerSizeUpdaterPlayer pointerScriptPlayer;

    [HideInInspector]
    public DialogueTextManager textManager;
    [HideInInspector]
    public RectTransform arrowRect;
    [HideInInspector]
    public RectTransform circleOrgRect;
    [HideInInspector]
    public RectTransform circleUpdRect;
    [HideInInspector]
    public RectTransform backgroundRect;
    [HideInInspector]
    public RectTransform pointerRect;
    [HideInInspector]
    public RectTransform horizontalGroupRect;
    // Start is called before the first frame update
    void Awake()
    {
        GetObjects();
        GetRectTransforms();
    }
    private void GetObjects()
    {
        textManager = FindObjectOfType<DialogueTextManager>();
        arrowIndex = GetComponentInChildren<ArrowIndexEnabler>();
        circleOrganizer = GetComponentInChildren<SelectionCircleOrganizer>();
        circleUpdater = GetComponentInChildren<SelectionCircleSizeUpdater>();
        horizontalGroup = GetComponentInChildren<SelectioinGroupSizeUpdater>();
        Background = GetComponentInChildren<EffectScriptsManager>();
        pointerScriptPlayer = GetComponentInChildren<PointerSizeUpdaterPlayer>();
    }
    private void GetRectTransforms()
    {
        arrowRect = arrowIndex.GetComponent<RectTransform>();
        circleOrgRect = circleOrganizer.GetComponent<RectTransform>();
        circleUpdRect = circleUpdater.GetComponent<RectTransform>();
        backgroundRect = Background.transform.parent.GetComponent<RectTransform>();
        pointerRect = pointerScriptPlayer.GetComponent<RectTransform>();
        horizontalGroupRect = horizontalGroup.GetComponent<RectTransform>();
    }
}
