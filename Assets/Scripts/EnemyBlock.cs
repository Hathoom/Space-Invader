using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    private int enemyleft = 15;

    private float actionOffset = 1.5f;
    private float timePassed = 0f;
    
    // how many moves have been done in a direction
    private float movesindirection = 0f;
    private int moveLeftRight = 1;
    private float moveDistance = 1.25f;

    private Enemy[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        //get reference to all of the enemy's scripts
        enemies = new Enemy[15];
        for (int i = 0; i < 15; i++)
        {
            enemies[i] = transform.GetChild(i).gameObject.GetComponent<Enemy>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //enemy movement based off of time
        timePassed += Time.deltaTime;
        if (timePassed >= actionOffset)
        {
            timePassed = 0f;

            movesindirection += moveLeftRight;
            if (movesindirection == 5f || movesindirection == -5)
            {
                transform.position = transform.position + new Vector3(0f, moveDistance * -1, 0f);
                moveLeftRight = moveLeftRight * -1;
            }
            else
            {
                transform.position = transform.position + new Vector3(moveDistance * moveLeftRight, 0f, 0f);
            }

            //shoot every time we move, this is temporary
            RandomShoot(Random.Range(0, 14));
        }

    }


    private void SpawnBlock()
    {
        //respawn enemy block
        enemyleft = 15;
        actionOffset = 1.5f;
        movesindirection = 0f;
        moveLeftRight = 1;

        for (int i = 0; i < 15; i++)
        {
            enemies[i].Respawn();
        }
        transform.position = new Vector3(0f, 3f, 0f);
    }


    public void EnemyDied()
    {
        enemyleft = enemyleft - 1;
        actionOffset = actionOffset - .075f;

        if (enemyleft == 0)
        {
            SpawnBlock();
        }
    }

    private void RandomShoot(int index)
    {
        enemies[index].Shoot();
    }
}
