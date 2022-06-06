using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteRotationsInScene : MonoBehaviour
{
    private SpriteRenderer[] spritresInScene;
    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
        spritresInScene = Resources.FindObjectsOfTypeAll<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetRotSprites();
    }

  private void SetRotSprites()
    {
        foreach(SpriteRenderer sprite in spritresInScene)
        {
            if (!sprite.tag.ToLower().Contains("dialogue"))
            {
                Quaternion spriteRot = sprite.transform.rotation;
                sprite.transform.Rotate(new Vector3(mainCamera.transform.rotation.x, spriteRot.y, spriteRot.z));
            }
               
        }
    }
}
