using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    List<GameObject> enemies = new List<GameObject>();

    //[Range(-2.0f, 2.5f)]
    //public float spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count >= 0 && enemies.Count < 10)
        {
            Vector2 randomSpawnPoint = new Vector2(RandomSpawn(), 8.0f);
            GameObject newEnemy = Instantiate(enemy, randomSpawnPoint, Quaternion.identity);
            enemies.Add(newEnemy);
        }
    }

    float RandomSpawn()
    {
        float rand = Random.Range(-2.0f, 2.5f);
        return rand;
    }
}
