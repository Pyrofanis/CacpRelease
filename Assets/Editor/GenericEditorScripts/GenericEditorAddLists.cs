using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GenericEditorAddLists 
{
    public static void AddOnCurrentListButton(List<PlayerStates.ResponseAndEmotion> listToApply, string name)
    {
        if (GUILayout.Button("Add " + name, GUILayout.Height(30), GUILayout.Width(120), GUILayout.ExpandWidth(false)))
        {
            AddElementToList(listToApply);
        }
    }
    public static void AddElementToList(List<PlayerStates.ResponseAndEmotion> listToApply)
    {
        listToApply.Add(new PlayerStates.ResponseAndEmotion("Hello Word!!! Write something here... maybe? since you added me",PlayerStates.Emotions.neutral));
    }
}
