/***
 * Created By: Aidan Pohl
 * Created: April 6, 2022
 * 
 * Last Edited by: N?/A
 * 
 * Description: Return Object to Pool
 * 
 * 
 ***/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    ObjectPool pool;

    private void Awake()
    {
        pool = ObjectPool.POOL;
    }

    private void OnDisable()
    {
        if (pool != null)
        {
            pool.ReturnObject(this.gameObject); //return this object to pool
        }
    }
}
