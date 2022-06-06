using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DialogueSOEditorAdd 
{


    public static void AddPlayerButton(DialogueScriptableObject dialogueToApplyTo)
    {
        if (GUILayout.Button("Add Player", GUILayout.Height(30), GUILayout.Width(80), GUILayout.ExpandWidth(false)))
        {
            GenericEditorAddLists.AddElementToList(dialogueToApplyTo.playerResponseNEmotion);
        }
    }
    public static void AddNpcResponseButton(DialogueScriptableObject currentScriptable,DialogueScriptableObject newSOInstance)
    {
        if (GUILayout.Button("Add Npc", GUILayout.Height(30), GUILayout.Width(80), GUILayout.ExpandWidth(false)))
        {
            CreateDialogueBox(currentScriptable,newSOInstance);
        }
    }
    public static void AddBoth(DialogueScriptableObject currentScriptable, DialogueScriptableObject newSOInstance)
    {
        if (GUILayout.Button("Add both", GUILayout.Height(30), GUILayout.Width(80), GUILayout.ExpandWidth(false)))
        {

            CreateDialogueBox( currentScriptable, newSOInstance);
            GenericEditorAddLists.AddElementToList(currentScriptable.playerResponseNEmotion);
        }
    }
    public static void CreateDialogueBox(DialogueScriptableObject currentScriptable,DialogueScriptableObject newScriptableObject)
    {
        AddPreviousDialogueAndResponse(currentScriptable, newScriptableObject);
        AddIndicatorForToolUser(newScriptableObject);



        string path = AssetDatabase.GenerateUniqueAssetPath(AssetDatabase.GetAssetPath(currentScriptable));
        AssetDatabase.CreateAsset(newScriptableObject, path);
        AssetDatabase.SaveAssets();
    }
    private static void AddPreviousDialogueAndResponse(DialogueScriptableObject currentScriptableObject, DialogueScriptableObject scriptableObject)
    {
        scriptableObject.previouScriptableObject = currentScriptableObject;
        currentScriptableObject._DialogueToRedirectTo.Add(scriptableObject);
    }
    private static void AddIndicatorForToolUser(DialogueScriptableObject scriptableObject)
    {
        scriptableObject.Npcresponse = "Add npces Responce";
    }
    public static void AddBreakPointButton(DialogueScriptableObject scriptableObjectToApplyTo)
    {
        if (GUILayout.Button("Add BreakPoint", GUILayout.Height(30), GUILayout.Width(180), GUILayout.ExpandWidth(false)))
        {
            AddBreakPoint(scriptableObjectToApplyTo);
        }
    }
    private static void AddBreakPoint(DialogueScriptableObject scriptableObjectToApplyTo)
    {
        scriptableObjectToApplyTo._DialogueToRedirectTo.Add(null);
    }
}
