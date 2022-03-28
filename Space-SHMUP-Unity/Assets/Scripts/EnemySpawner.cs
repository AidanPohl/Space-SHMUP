/**** 
 * Created by: Aidan Pohl
 * Date Created: March 28, 2022
 * 
 * Last Edited by: N/A
 * Last Edited: March 28, 2022
 * 
 * Description: Spawns Enemies
****/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ /***VARIABLES***/
    [Header("Enemy Settings")]
    public GameObject[] prefabEnemies; //Array of all enemy prefabs
    public float enemiesSpawnPerSecond; //Enemy count to spawn per second
    public float enemyDefaultPadding; //Padding position of each enemy

    private BoundsCheck bndCheck; //Reference to the bounds check component;
   
    // Start is called before the first frame update
    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemiesSpawnPerSecond);
    }//end Start()

    void SpawnEnemy()
    {
        //pick a random enemy to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject enemyGO = Instantiate<GameObject>(prefabEnemies[ndx]);

        //Position the enemy above the screen with a random x position;
        float enemyPadding = enemyDefaultPadding;
        if (enemyGO.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(enemyGO.GetComponent<BoundsCheck>().radius);
        }

        //Set the initial position
        Vector3 pos = Vector3.zero;

        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax);           //rand between min and max
        pos.y = bndCheck.camHeight + enemyPadding; //height+padding, offscreen

        enemyGO.transform.position = pos;

        //Invoke again
        Invoke("SpawnEnemy", 1f / enemiesSpawnPerSecond);
    }//end SpawnEnemy()
}
