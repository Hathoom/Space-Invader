using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : MonoBehaviour
{
    private Animator enemyAnimator;

    private static readonly int Destroyed = Animator.StringToHash("Destroyed");

    private UI ui;

    public float speed = 1f;

    public bool menuFlag = false;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();

        //all enemies get the UI
        ui = FindObjectOfType<UI>();

        if (!menuFlag)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        //make sure they only check for getting shot by player bullet
        if(collision.gameObject.tag == "bullet")
        {
            // add to points
            if (this.tag == ("Cancer"))
            {
                ui.updateScore(100);
            }

            Destroy(collision.gameObject); // destroy bullet

            // start death animation for a small amount of time
            enemyAnimator.SetTrigger(Destroyed);

            Destroy(gameObject, 1f);

        }
    }
}
