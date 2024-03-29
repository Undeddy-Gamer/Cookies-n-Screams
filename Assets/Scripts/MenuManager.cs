﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Runs on a button click and takes an int input
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); //Loads a secne from the number given
    }
    //Stops the unity editor and if in normal play exits the appication 
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying =
            false;
#endif 
        Application.Quit();
    }
}
