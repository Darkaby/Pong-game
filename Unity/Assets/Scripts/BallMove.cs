using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("StartPoint").GetComponent<Direction>().goingRight)
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        else
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed; 
    }

    float HitFactor(Vector2 ball, Vector2 racket, float racHeight)
    {
        return (ball.y - racket.y) / racHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketLeft")
        {
            FindObjectOfType<AudioManager>().Clip("HitRacket").Play();

            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 Dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = Dir * speed;
        }

        else if (collision.gameObject.name == "RacketRight")
        {
            FindObjectOfType<AudioManager>().Clip("HitRacket").Play();

            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 Dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = Dir * speed;
        }

        else if (collision.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Clip("HitWall").Play();
        }
    }
}
