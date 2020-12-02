using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSkeletons : MonoBehaviour
{
    private GameObject prefabEnemy;
    [SerializeField]
    private GameObject[] enemiesToSpawn;
    [SerializeField]
    private float timeBetweenInstances;
    [SerializeField]
    private int maxEnemies;
    [SerializeField]
    private GameObject summoningArea;

    private int enemiesCreated = 0;
    private const float MIN_ANGLE = -45;
    private const float MAX_ANGLE = 45;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSkeletons",0,timeBetweenInstances);
    }

    void SpawnSkeletons() {

        //Instantiating summoning particle effect
        Vector3 summoningY = new Vector3(-90, 0, 0);
        Vector3 rotation = new Vector3(0, Random.Range(MIN_ANGLE, MAX_ANGLE), 0); 
        GameObject summoning = Instantiate(summoningArea, transform.position, Quaternion.Euler(summoningY));
        
        prefabEnemy = Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)]);
        Instantiate(prefabEnemy, transform.position, Quaternion.Euler(rotation));
        
        enemiesCreated++;
        if (enemiesCreated == maxEnemies) {
            CancelInvoke();
        }
    }
}
