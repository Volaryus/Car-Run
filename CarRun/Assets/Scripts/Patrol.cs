using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float[] posX;
    public float speed = 5f;
    Rigidbody2D rb;
    bool moveRight = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > posX[0] && !moveRight)
        {
            rb.velocity = new Vector2(-speed, 0);
            //transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x < posX[1])
        {
            moveRight = true;
            rb.velocity = new Vector2(speed, 0);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            moveRight = false;
        }
    }
}
