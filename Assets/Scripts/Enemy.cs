using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnimator;

    private static readonly int Destroyed = Animator.StringToHash("Destroyed");

    private UI ui;

    private EnemyBlock parent;

    private BoxCollider2D collider2D;
    private SpriteRenderer renderer;

    public GameObject enemyBulletPrefab;
    public Transform enemyShootingOffsetTransform;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();

        //all enemies get the UI
        ui = FindObjectOfType<UI>();

        parent = GameObject.FindGameObjectWithTag("parent").GetComponent<EnemyBlock>();


        collider2D = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        //make sure they only check for getting shot by player bullet
        if(collision.gameObject.tag == "bullet")
        {
            // add to points
            if (this.tag == ("Sore"))
            {
                ui.updateScore(10);
            }
            else if (this.tag == ("Blister"))
            {
                ui.updateScore(20);
            }
            else if (this.tag == ("Callous"))
            {
                ui.updateScore(40);
            }

            Destroy(collision.gameObject); // destroy bullet

            // start death animation for a small amount of time
            enemyAnimator.SetTrigger(Destroyed);

            //make it so while enemy is "dying" they won't trigger anything else
            collider2D.enabled = false;

            // disable the enemy sprite
            renderer.enabled = false;

            // inform parent child died
            parent.EnemyDied();

        }
    }


    public void Respawn()
    {
        collider2D.enabled = true;
        renderer.enabled = true;
        enemyAnimator.SetTrigger(Destroyed);
    }


    public void Shoot()
    {
        GameObject enemyShot = Instantiate(enemyBulletPrefab, enemyShootingOffsetTransform.position, Quaternion.identity);
    
        Destroy(enemyShot, 3f);
    }
}
