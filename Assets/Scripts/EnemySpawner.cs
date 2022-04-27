using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    List<GameObject> enemies = new List<GameObject>();

    float spawnTime = 2f;
    float elapsedTime = 0f;


    //[Range(-2.0f, 2.5f)]
    //public float spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(spawnTime);
        elapsedTime += Time.deltaTime;
        if(enemies.Count >= 0 && enemies.Count < 10)
        {
            if(elapsedTime > spawnTime)
            {
                elapsedTime = 0;
                Vector2 randomSpawnPoint = new Vector2(RandomSpawn(), 8.0f);
                GameObject newEnemy = Instantiate(enemy, randomSpawnPoint, Quaternion.identity);
                enemies.Add(newEnemy);
            }

        }
    }


    float RandomSpawn()
    {
        float rand = Random.Range(-2.0f, 2.5f);
        return rand;
    }
}
