using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacketLeft : MonoBehaviour
{
    public float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.X))
            transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
