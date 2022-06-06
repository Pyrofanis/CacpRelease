using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneSupporting : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    public int SceneIndex;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
