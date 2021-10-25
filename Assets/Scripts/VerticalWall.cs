using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalWall : MonoBehaviour
{
    // Score
    private int score = 0;
    // Text to display score
    public Text txt;
    // Prefab of the ball
    public GameObject ball;
    // Direction of the ball (true = right, false = left)
    private bool direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Increment score and display it
        score++;
        txt.text = "" + score;

        FindObjectOfType<AudioManager>().Clip("BallOut").Play();

        // Specify the direction in which the ball goes
        direction = (gameObject.name == "WallLeft") ? true : false;
        GameObject.Find("StartPoint").GetComponent<Direction>().goingRight = direction;

        Invoke("ThrowBall", 1f);
        // Destroy the ball
        Destroy(collision.gameObject);
    }

    void ThrowBall()
    {
        // Instantiate the ball at the starting point
        if (!GameManager.gameEnded)
        {
            Debug.Log("Instantiate ball");
            Instantiate(ball, GameObject.Find("StartPoint").GetComponent<Transform>().transform.position, Quaternion.identity);
        }
            
    }
}
