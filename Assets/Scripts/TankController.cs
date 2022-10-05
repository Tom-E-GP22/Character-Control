using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float speed = 5f;
    float rotateSpeed = -0.25f;

    Rigidbody2D rb2d;
    Transform shootingHut;
    Vector3 shootPos;
    public GameObject bulletPrefab;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shootingHut = GameObject.Find("ShootingHut").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        shootPos = GameObject.Find("shootPos").GetComponent<Transform>().position;

        float rotation = x * rotateSpeed;
        rb2d.rotation += rotation;

        rb2d.velocity = transform.up * speed * y;

        //Rotate Shoot to Mouse
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        shootingHut.up = (Vector3)mousePos - transform.position;

        //shoot
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPos, shootingHut.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = shootingHut.transform.up * 10f;
            bullet.GetComponent<Rigidbody2D>().velocity += rb2d.velocity;
            Destroy(bullet, 3f);
        }
    }
}
