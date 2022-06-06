using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenu : MonoBehaviour
{
    DialogueManager dialogueManager;

    [SerializeField]
    public GameObject objectToEnable;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.scriptableObject == null)
        {
            objectToEnable.SetActive(true);
        }
    }
}
