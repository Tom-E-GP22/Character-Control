using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject boxExplosion;
    Vector2 holder;

    void Start()
    {
        holder = gameObject.GetComponent<Rigidbody2D>().velocity;
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("Destroyable"))
        {
            Instantiate(boxExplosion,transform.position, Quaternion.identity);
            Destroy(hit.gameObject);
            gameObject.GetComponent<Rigidbody2D>().velocity = holder;
        }
        else
        {
            Instantiate(explosion,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
            
    }
}
