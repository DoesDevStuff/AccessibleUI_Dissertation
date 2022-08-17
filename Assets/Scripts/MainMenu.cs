using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This assumes we have a plain page for Menu as a basic separate scene
//And that options / settings menu / pause menu are all separate canvas

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject optionsScreen;
    

    void Start()
    {

    }


    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    /// <summary>
    /// Loads Options Menu
    /// </summary>
    public void OpenOptions()//opens options menu
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()//closes and sets canvas back to invisible
    {
        optionsScreen.SetActive(false);
    }
    

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
