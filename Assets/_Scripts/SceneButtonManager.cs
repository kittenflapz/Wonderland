/* Filename: SceneManager.cs
 * Author: Catt Symonds
 * Student number: 101209214
 * Date last modified: 05/11/2020
 * Description: Buttons for switching between scenes
 * 
 * Revision History
 * 05/11/2020: File created */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonManager : MonoBehaviour
{

    /// <summary>
    /// Loads the instructions scene
    /// </summary>
    public void LoadInstructions()
    {
        LoadSceneWithString("Instructions");
    }

    /// <summary>
    /// Loads the main menu scene
    /// </summary>
    public void LoadMenu()
    {
        LoadSceneWithString("Menu");
    }

    /// <summary>
    /// Loads a scene with a string of the scene name
    /// </summary>
    /// <param name="sceneName"></param>
    private void LoadSceneWithString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
