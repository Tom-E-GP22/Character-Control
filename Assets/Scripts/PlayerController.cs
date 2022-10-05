using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    [Header ("Move Type")]

    public bool translateMove = false; 
    public bool velocityMove = false; 
    public bool forceMove = false;
    int previousActive = 0;

    float speed = 5f;
    SpriteRenderer sr;
    Rigidbody2D rb2d;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(translateMove)
        {
            Vector3 movement = new Vector3(x,y,0).normalized * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else if(velocityMove)
        {
            Vector2 movement = new Vector2(x,y) * speed;
            rb2d.velocity = movement;
        }
        else if(forceMove)
        {
            Vector2 movement = new Vector2(x, y);
            rb2d.AddForce(movement);
        }

        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if(transform.position.x > mousePos.x)
            sr.flipX = true;
        else if(transform.position.x < mousePos.x)
            sr.flipX = false;

        ToggleGroup();
    }

    void ToggleGroup()
    {
        if(translateMove && previousActive != 0)
        {
            velocityMove = false;
            forceMove = false;
            previousActive = 0;
        }
        else if(velocityMove && previousActive != 1)
        {
            translateMove = false;
            forceMove = false;
            previousActive = 1;
        }
        else if(forceMove && previousActive != 2)
        {
            translateMove = false;
            velocityMove = false;
            previousActive = 2;
        }
    }
}
