using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public  class DialogueSODeleteUnWanted 
{


    public static void RemoveBothButton(DialogueScriptableObject dialogueToApplyTo)
    {
        if (GUILayout.Button("Remove Both", GUILayout.Height(30), GUILayout.Width(100), GUILayout.ExpandWidth(false)))
        {
            GenericEditorRemoveLists.RemoveElementFromList(dialogueToApplyTo.playerResponseNEmotion);
            RemoveNpcResponse(dialogueToApplyTo);
        }
    }

    public static void RemovePlayerRespButton(DialogueScriptableObject dialogueToApplyTo)
    {
        if (GUILayout.Button("Remove Player", GUILayout.Height(30), GUILayout.Width(100), GUILayout.ExpandWidth(false)))
        {
            GenericEditorRemoveLists.RemoveElementFromList(dialogueToApplyTo.playerResponseNEmotion);
        }
    }
    public static void RemoveNpcRespButton(DialogueScriptableObject dialogueToApplyTo)
    {
        if (GUILayout.Button("Remove Npc", GUILayout.Height(30), GUILayout.Width(100), GUILayout.ExpandWidth(false)))
        {
            RemoveNpcResponse(dialogueToApplyTo);
        }
    }
    private static void RemoveNpcResponse(DialogueScriptableObject dialogueToApplyTo)
    {
        if ( dialogueToApplyTo._DialogueToRedirectTo.Count > 0)
        {
            if (dialogueToApplyTo._DialogueToRedirectTo[dialogueToApplyTo._DialogueToRedirectTo.Count - 1] != null)
            {
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(dialogueToApplyTo._DialogueToRedirectTo[dialogueToApplyTo._DialogueToRedirectTo.Count - 1]));
            }       
            dialogueToApplyTo._DialogueToRedirectTo.RemoveAt(dialogueToApplyTo._DialogueToRedirectTo.Count - 1);
        }
    }

}
