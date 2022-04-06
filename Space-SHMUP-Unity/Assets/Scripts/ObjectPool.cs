/***
 * Created By: Aidan Pohl
 * Created: April 6, 2022
 * 
 * Last Edited by: N?/A
 * 
 * Description: Object Pool for objects
 * 
 * 
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region POOL Singleton
    static public ObjectPool POOL;
    void checkPOOLIsInScene()
    {
        if(POOL == null)
        {
            POOL = this;
        }
        else
        {
            Debug.LogError("POOL.Awake() - Attempted to assign a second ObjectPool.POOL you daft f");
        }
    }
    #endregion

    private Queue<GameObject> projectiles = new Queue<GameObject>(); //queue of game projectiles to be added to the pool

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;
    private void Awake()
    {
        checkPOOLIsInScene();
    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < poolStartSize; i++)
        {
            GameObject gObject = Instantiate(projectilePrefab,transform);
            projectiles.Enqueue(gObject); //add to queue
            gObject.SetActive(false);
        }//end for loop
    }//end Start()

    public GameObject GetObject()
    {
        if(projectiles.Count > 0)
        {
            GameObject gObject = projectiles.Dequeue();
            gObject.SetActive(true);
            return gObject;
        }
        else {
            Debug.LogWarning("Out of Projectiles, Reloading you wasteful c");
            return null; 
        }//end if else
    }//end getObject()

    public void ReturnObject(GameObject gObject)
    {
        projectiles.Enqueue(gObject);
        gObject.SetActive(false);
    }//end ReturnObject(GameObject)
}
