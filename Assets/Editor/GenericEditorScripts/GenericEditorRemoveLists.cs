using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericEditorRemoveLists
{
    public static void RemoveElementFromListButton(List<PlayerStates.ResponseAndEmotion> listToApply, string name)
    {
        if (GUILayout.Button("Remove " + name, GUILayout.Height(30), GUILayout.Width(150), GUILayout.ExpandWidth(false)))
        {
            RemoveElementFromList(listToApply);
        }
    }
    public static void RemoveElementFromList(List<PlayerStates.ResponseAndEmotion> listToApply)
    {
        if (listToApply.Count > 0)
            listToApply.RemoveAt(listToApply.Count - 1);
    }
}
