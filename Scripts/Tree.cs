using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////
// Written by: Jayden Alton
// Associate writing: 
// Last Modified: 1/25/2023
////////////////////////////
///
public class Tree : MonoBehaviour
{
    public float startTreeHP;
    private float treeHP;

    private Vector2 prevTreePos;
    // Start is called before the first frame update
    void Start()
    {
        treeHP = startTreeHP;
        prevTreePos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //resets the next tree with a certain amount of hp base on player score
    public void Respawn(int currPlayerScore)
    {
        transform.position = new Vector2(prevTreePos.x + 5f, prevTreePos.y);
        prevTreePos = transform.position;
        treeHP = startTreeHP + currPlayerScore * 10;
    }
    public float getTreeHP()
    {
        return treeHP; 
    }
    public void setTreeHP(float val)
    {
        treeHP = val;
    }
}
