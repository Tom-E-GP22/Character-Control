using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public bool[] moveType = new bool[3];
    bool moveTypeToggle = true;

    float speed = 5f;
    SpriteRenderer sr;
    Rigidbody2D rb2d;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(false)
        {
            Vector3 movement = new Vector3(x,y,0).normalized * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else if(true)
        {
            Vector2 movement = new Vector2(x,y) * speed;
            rb2d.velocity = movement;
        }

        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if(transform.position.x > mousePos.x)
            sr.flipX = true;
        else if(transform.position.x < mousePos.x)
            sr.flipX = false;
    }
}
