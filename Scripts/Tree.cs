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
    public int treeHP;

    private Vector2 prevTreePos;
    // Start is called before the first frame update
    void Start()
    {
        treeHP = 25;
        prevTreePos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //resets the next tree with a certain amount of hp base on player score
    public void Respawn(int currPlayerScore)
    {
        transform.position = new Vector2(prevTreePos.x + 5, prevTreePos.y);
        prevTreePos = transform.position;
        treeHP = 25;
        switch(currPlayerScore/10)
        {
            case 0:
                break;
            case 1:
                treeHP += 5;
                break;
            case 2:
                treeHP += 10;
                break;
            case 3:
                treeHP += 15;
                break;
            default: 
                treeHP += 15;
                break;
        }
    }
}
