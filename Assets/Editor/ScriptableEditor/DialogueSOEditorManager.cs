using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DialogueScriptableObject))]
public class DialogueSOEditorManager : Editor
{
    public DialogueScriptableObject defaultScriptable;
    private DialogueScriptableObject targetSO;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CurrentSO();
        ButtonsToShow(targetSO,InstanceOfScriptableObject());
    }



    private void ButtonsToShow(DialogueScriptableObject viewingDialoge,DialogueScriptableObject newInstance)
    {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        DialogueSOEditorAdd.AddPlayerButton(viewingDialoge);
        DialogueSODeleteUnWanted.RemovePlayerRespButton(viewingDialoge);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        DialogueSOEditorAdd.AddNpcResponseButton(viewingDialoge, newInstance);
        DialogueSODeleteUnWanted.RemoveNpcRespButton(viewingDialoge);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        DialogueSOEditorAdd.AddBoth(viewingDialoge, newInstance);
        DialogueSODeleteUnWanted.RemoveBothButton(viewingDialoge);
        GUILayout.EndHorizontal();

        DialogueSOEditorAdd.AddBreakPointButton(viewingDialoge);

        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        DialogueSOEditorUttility.RenameButton(viewingDialoge);
        DialogueSOEditorUttility.TrimExessButton(viewingDialoge);
        DialogueSOEditorUttility.NoNpcResponseButton(viewingDialoge);
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();

    }
    private void CurrentSO()
    {   if (target is DialogueScriptableObject)
        targetSO = (DialogueScriptableObject)target;
    }
    private DialogueScriptableObject InstanceOfScriptableObject()
    {
        return Instantiate(defaultScriptable);
    }




}
