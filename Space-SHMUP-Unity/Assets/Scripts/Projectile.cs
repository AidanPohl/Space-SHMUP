/**** 
 * Created by: Aidan Pohl
 * Date Created: March 30, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 30, 2022
 * 
 * Description: Hero ship controller
****/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /***VARIABLES***/
    private BoundsCheck bndCheck;

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {   
        //if offscreen up
        if (bndCheck.offUp)
        {
            gameObject.SetActive(false);
            bndCheck.offUp = false;
        }//if (bndCheck.offUp)
    }
}
