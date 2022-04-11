/***
 * Created By: Aidan Pohl
 * Created: April 11, 2022
 * 
 * Last Edited by: N?/A
 * 
 * Description: Scrolls material
 * 
 * 
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    //**Variables**//

    private Material goMat; //the game object's material
    private Renderer goRenderer; //the game objects renderer

    public Vector2 scrollSpeed = new Vector2(0, 0); //x and y speed of materials scrolling

    private Vector2 offset; //the offset of the scroll over time

    // Start is called before the first frame update
    void Start()
    {
        goRenderer = GetComponent<Renderer>();
        goMat = goRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = (scrollSpeed * Time.deltaTime);
        goMat.mainTextureOffset += offset;
    }
}
