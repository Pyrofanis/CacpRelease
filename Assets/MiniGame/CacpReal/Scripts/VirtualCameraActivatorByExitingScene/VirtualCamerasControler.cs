using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamerasControler : MonoBehaviour
{
    [System.Serializable]
    public struct LevelNVirtualCamera
    {
        public string objectName;
        public GameObject objectWithVirtualCamera;
        public LevelNVirtualCamera(string newString,GameObject newVirtualCamera)
        {
            this.objectName = newString;
            this.objectWithVirtualCamera = newVirtualCamera;
        }
    }

    public List<LevelNVirtualCamera> sceneNVirtualCameras;
    private int index = 0;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.ToLower().Contains(sceneNVirtualCameras[index].objectName.ToLower()))
        {
            PrepareNextObj(sceneNVirtualCameras, index);
            
        }
    }
    private void PrepareNextObj(List<LevelNVirtualCamera> gameObject,int index)
    {
        gameObject[index].objectWithVirtualCamera.SetActive(false);
        if(gameObject.Count>index+1)
        gameObject[index + 1].objectWithVirtualCamera.SetActive(true);
        index++;
    }
}
