using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager epInstance;

    public List<GameObject> enemies;
    public List<Transform> enemySpawn;
    public int enemyCount;
    public GameObject enenmyPF;



    // Start is called before the first frame update
    void Start()
    {
        InitPool();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitPool()
    {
        enemies = new List<GameObject>(); // Create our pool.
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject temp = Instantiate(enenmyPF); // Instantiate an object
            temp.transform.position = enemySpawn[i].position;
            temp.SetActive(false);                    // Start inactive
            enemies.Add(temp);                          // Add it to the pool
        }
    }

    public void SpawnEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
            }
        }
    }


}
