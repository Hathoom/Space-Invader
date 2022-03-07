using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    public float health = 5f;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet" || collision.gameObject.tag == "enemybullet")
        {
            Destroy(collision.gameObject); // destroy bullet

            health = health - 1f;

            if (health == 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "bullet" || collision.gameObject.tag == "enemybullet")
        {

            Destroy(collision.gameObject); // destroy bullet

            health = health - 1f;

            if (health == 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
