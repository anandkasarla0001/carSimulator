using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [Header("All Menu's")] // header for all menuu
    public GameObject pauseMenuUI; // object for pause  menu
    public GameObject playerUI;
    public static bool GameIsStopped = false; // checks whether the game is  stopped / not

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // helps to disable the pause menu 
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsStopped = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsStopped = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene("scene_day"); // restart the scene 
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Garage"); // loads  the  Garage scene 
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game!!!"); // helps to test the game in unity
        Application.Quit(); // helps to test the game in mobile
    }

}
