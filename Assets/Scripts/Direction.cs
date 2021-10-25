using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public bool goingRight = true;
    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Instantiate first ball");
        Invoke("ThrowBall", 1f);
    }

    void ThrowBall()
    {
        // Instantiate the ball at the starting point
        Instantiate(ball, GameObject.Find("StartPoint").GetComponent<Transform>().transform.position, Quaternion.identity);
    }
}
