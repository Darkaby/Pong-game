using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public static bool gamePaused;

    public MenuManager menu;

    public Text scoreRight;
    public Text scoreLeft;
    public Text overallScore;

    public int highestScore;
    private string score;

    private void Awake()
    {
        gameEnded = false;
        gamePaused = false;
        score = $"{highestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !gamePaused)
        {
            gamePaused = true;
            menu.PauseGame();
        }

        if (scoreLeft.text==score || scoreRight.text == score)
        {
            gameEnded = true;
            FindObjectOfType<AudioManager>().Clip("GameOver").Play();

            Invoke("EndGame", 1.2f);

            //scoreMenu.SetActive(true);
            overallScore.text = $"{scoreLeft.text} | {scoreRight.text}";
            
        }
    }

    void EndGame()
    {
        menu.EndGame();
    }
}
