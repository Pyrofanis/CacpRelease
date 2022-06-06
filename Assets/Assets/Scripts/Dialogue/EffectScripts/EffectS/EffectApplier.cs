using UnityEngine;
using TMPro;

public class EffectApplier : MonoBehaviour
{
    private TMP_TextInfo _TextInfo;
    private TMP_CharacterInfo tMP_CharacterInfo;
    private TMP_MeshInfo tMP_Mesh;

    private EffectScriptsManager effectScriptsManager;
    private TextEffectTypes textEffectTypes;
    void Awake()
    {
        textEffectTypes = GetComponent<TextEffectTypes>();
        effectScriptsManager = GetComponent<EffectScriptsManager>();

        DialogueManagerStates.OnStateChange += ApplyWhenDialogueActive;
    }
    private void Start()
    {
        Initialization();
    }
    void ApplyWhenDialogueActive(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                ApplyLogicWithParameters();
                break;
        }

    }
    private void Initialization()
    {
        _TextInfo = effectScriptsManager.proUGUI.textInfo;
        tMP_CharacterInfo = _TextInfo.characterInfo[0];
        tMP_Mesh = _TextInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex];
    }
    private void ApplyLogicWithParameters()
    {
        ForceMeshUpdateOnCurrentTXT();
        if (effectScriptsManager.HasentFinishedTyping()||_TextInfo.linkCount==0)
            CallEffect(0, _TextInfo.characterCount, effectScriptsManager.xEffectIntensity, effectScriptsManager.yEffectIntensity);
        else
        {
            foreach (TextEffectTypes.TypeAndRange linkType in textEffectTypes.currentActiveLinks)
            {
                CallEffect(linkType.initialIndex, linkType.linkCharLength, linkType.effectTypeAndEffectiveness.xEffectivity, linkType.effectTypeAndEffectiveness.yEffectivity);
            }
            foreach (TextEffectTypes.TypeAndRange generalChars in textEffectTypes.generalCharacters)
            {
                CallEffect(generalChars.initialIndex, generalChars.linkCharLength, generalChars.effectTypeAndEffectiveness.xEffectivity, generalChars.effectTypeAndEffectiveness.yEffectivity);
            }
        }

    }
    private void CallEffect(int initalIndex, int charLength, float xEffectivity, float yEffectivity)
    {
        _TextInfo = effectScriptsManager.proUGUI.textInfo;
        CreateDraftVerticies(initalIndex,charLength,xEffectivity,yEffectivity);
        DrawDraftVerticies();
    }
    private void CreateDraftVerticies(int initalIndex,int charLength,float xEffectivity,float yEffectivity)
    {
        for (int i = initalIndex; i < charLength; i++)
        {
            Vector3 offset = effectScriptsManager.TrembleAndWomble(Time.time + i, xEffectivity, yEffectivity);
            tMP_CharacterInfo = _TextInfo.characterInfo[i];
            tMP_Mesh = _TextInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex];
          
                    if (!tMP_CharacterInfo.isVisible)
                    {
                        continue;
                    }
                    int index = tMP_CharacterInfo.vertexIndex;

                    for (int j = 0; j < 4; j++)
                    {
                        tMP_Mesh.vertices[index + j] += offset;
                    }
           
     

        }
    }
    private void DrawDraftVerticies()
    {
        for (int i = 0; i < _TextInfo.meshInfo.Length; i++)
        {
            if (!tMP_CharacterInfo.isVisible)
            {
                continue;
            }
            tMP_Mesh.mesh.vertices = tMP_Mesh.vertices;
            effectScriptsManager.proUGUI.UpdateGeometry(tMP_Mesh.mesh, i);
        }

    }

    private void ForceMeshUpdateOnCurrentTXT()
    {
        effectScriptsManager.proUGUI.ForceMeshUpdate();
    }

}
