//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//public class TransferSOData : MonoBehaviour
//{
//    public List<DialogueScriptableObject> dialogueBoxesCreated;
//    public int index;
//    public bool initiated = false;
//    private void Awake()
//    {
//        //dialogueBoxesCreated = Resources.FindObjectsOfTypeAll<DialogueScriptableObject>();
//        FindScriptables();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        WhereToApply();
//    }
//    private void FindScriptables()
//    {
//        foreach (string s in AssetDatabase.GetAllAssetPaths())
//        {
//            Object currentAsset = AssetDatabase.LoadMainAssetAtPath(s);
//            DialogueScriptableObject currentGO = (currentAsset) as DialogueScriptableObject;
//            if (currentGO != null && currentGO != null)
//            {
//                dialogueBoxesCreated.Add(currentGO);
//            }
//        }
//    }
//    private void WhereToApply()
//    {
//        if ((Input.GetKeyDown(KeyCode.Space) || initiated) && dialogueBoxesCreated.Count > index)
//        {
//            initiated = !initiated;
//            foreach (DialogueScriptableObject scriptableObject in dialogueBoxesCreated)
//            {
//                index++;
//                EditorUtility.SetDirty(scriptableObject);
//                WhatToDo(scriptableObject);
//            }
//        }
//        if (Input.GetKeyDown(KeyCode.Return) && index >= dialogueBoxesCreated.Count - 1)
//        {
//            Debug.Log("PRESS ENTER TO SAVE CHANGES TO DISK!!!!");
//            AssetDatabase.SaveAssets();
//        }
//        if (Input.GetKeyDown(KeyCode.Return))
//        {
//            Debug.Log("PRESS ENTER TO SAVE CHANGES TO DISK!!!!");
//            AssetDatabase.SaveAssets();
//        }

//    }
//    private void WhatToDo(DialogueScriptableObject currentScriptable)
//    {
//        //ListConverter(currentScriptable,currentScriptable._PlayerResponses);
//    }
//    private void ListConverter(DialogueScriptableObject currentScriptable, List<string> listToConvert)
//    {
//        for (int i = 0; i < listToConvert.Count; i++)
//        {
//            PlayerStates.ResponseAndEmotion PlayerResponseNEmotion = new PlayerStates.ResponseAndEmotion(listToConvert[i], PlayerStates.Emotions.neutral);
//            if (listToConvert.Count >= currentScriptable.playerResponseNEmotion.Count)
//                currentScriptable.playerResponseNEmotion.Add(PlayerResponseNEmotion);
//            if (i >= listToConvert.Count - 1)
//            {
//                index++;
//                Debug.Log("Finished at" + index + " object" + currentScriptable.name);
//                break;
//            }
//        }

//    }
//}

