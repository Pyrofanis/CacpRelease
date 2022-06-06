using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadScene
{
    public static void LoadClickedScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
