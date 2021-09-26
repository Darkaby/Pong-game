using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gameParts;
    public GameObject scores;

    public GameObject pauseMenu;
    public GameObject startMenu;
    public GameObject scoreMenu;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Clip("GameSound").Play();
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        Time.timeScale = 1f;

        gameParts.SetActive(true);
        startMenu.SetActive(false);
        scores.SetActive(true);

        //FindObjectOfType<AudioManager>().Clip("MenuSound").Stop();
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        // Pause the game
        Time.timeScale = 0f;

        pauseMenu.SetActive(true);

        //FindObjectOfType<AudioManager>().Clip("GameSound").Stop();
        //FindObjectOfType<AudioManager>().Clip("MenuSound").Play();
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        //FindObjectOfType<AudioManager>().Clip("MenuSound").Stop();
        //FindObjectOfType<AudioManager>().Clip("GameSound").Play();
    }

    public void QuitGame()
    {
        Application.Quit();

        // Go back to the main menu in the editor to see that we quitted
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        FindObjectOfType<AudioManager>().Clip("GameOver").Play();

        scoreMenu.SetActive(true);
        scores.SetActive(false);
        gameParts.SetActive(false);

        //FindObjectOfType<AudioManager>().Clip("GameSound").Stop();
        //FindObjectOfType<AudioManager>().Clip("MenuSound").Play();
    }
}
