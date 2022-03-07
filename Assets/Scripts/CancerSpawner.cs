using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerSpawner : MonoBehaviour
{
    public GameObject CancerPrefab;

    private float spawnChance = 0f;
    private float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= 0.5f)
        {
            timePassed = 0;

            spawnChance += 1f;
        }

        if (Random.Range(30f,100f) <= spawnChance)
        {
            SpawnCancer();
            spawnChance = 0f;
        }
    }


    private void SpawnCancer()
    {
        GameObject cancer = Instantiate(CancerPrefab, transform.position, Quaternion.identity);

        Destroy(cancer, 200f);
    }
}
