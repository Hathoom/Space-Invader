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

    private bool isDead = false;

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

            isDead = true;

            //make it so while enemy is "dying" they won't trigger anything else
            collider2D.enabled = false;

            StartCoroutine(DelayDeath(enemyAnimator.GetCurrentAnimatorStateInfo(0).length));

            // inform parent child died
            parent.EnemyDied();

        }
    }

    IEnumerator DelayDeath(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        renderer.enabled = false;
    }


    public void Respawn()
    {
        collider2D.enabled = true;
        renderer.enabled = true;
        isDead = false;
        enemyAnimator.SetTrigger(Destroyed);
    }


    public void Shoot()
    {
        GameObject enemyShot = Instantiate(enemyBulletPrefab, enemyShootingOffsetTransform.position, Quaternion.identity);
    
        enemyAnimator.SetTrigger("Shoot");

        Destroy(enemyShot, 3f);
    }

    public bool IsDead()
    {
        return isDead;
    }
}
