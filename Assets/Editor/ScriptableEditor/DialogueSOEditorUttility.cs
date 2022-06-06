using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogueSOEditorUttility 
{
    public static void RenameButton(DialogueScriptableObject dialogueToBeRenamed)
        {
        if (GUILayout.Button("Rename", GUILayout.Height(30), GUILayout.Width(80), GUILayout.ExpandWidth(false)))
        {
            RenameScriptableObject(dialogueToBeRenamed);
        }
    }

    private static void RenameScriptableObject(DialogueScriptableObject scriptableObject)
    {
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(scriptableObject), scriptableObject.newNameOfDialogueBox);
        AssetDatabase.SaveAssets();
    }
    public static void TrimExessButton(DialogueScriptableObject scriptableObjectToApplyTo)
    {
        if (GUILayout.Button("Delete Extra", GUILayout.Height(30), GUILayout.Width(80), GUILayout.ExpandWidth(false)))
        {
            TrimmExcessValuesAtListsOfScriptableObjects(scriptableObjectToApplyTo);
        }
    }
    private static void TrimmExcessValuesAtListsOfScriptableObjects(DialogueScriptableObject scriptableObject)
    {
        foreach (DialogueScriptableObject @object in scriptableObject._DialogueToRedirectTo)
        {
            if (@object == null)
            {
                scriptableObject._DialogueToRedirectTo.Remove(@object);
            }
        }
        int difference = Mathf.Abs(scriptableObject._DialogueToRedirectTo.Count - scriptableObject.playerResponseNEmotion.Count);
        if (scriptableObject.playerResponseNEmotion.Count > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                scriptableObject.playerResponseNEmotion.RemoveAt(Mathf.Abs(scriptableObject.playerResponseNEmotion.Count - i - 1));
            }
        }
       
    }
    public static void NoNpcResponseButton(DialogueScriptableObject scriptableObjectToApplyTo)
    {
        if (GUILayout.Button("No Npc", GUILayout.Height(30),GUILayout.Width(80), GUILayout.ExpandWidth(false)))
        {
            NoNpcResponse(scriptableObjectToApplyTo);
        }
    }
    private static void NoNpcResponse(DialogueScriptableObject scriptableObjectToApplyTo)
    {
        scriptableObjectToApplyTo.Npcresponse = "";
    }

}
