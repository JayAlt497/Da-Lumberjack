
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////
// Written by: Jayden Alton
// Associate writing: 
// Last Modified: 1/22/2023
////////////////////////////

public class Swipe : MonoBehaviour
{
    public GameObject player;
    public GameObject axe;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector2 axeStartPosition;
    public int maxSwipeHeight;
    public int minSwipeHeight;

    private void Start()
    {
        //marks the start position of the axe on phone screen
        axeStartPosition = axe.transform.position;
    }
    private void Update()
    {
        //Debug.Log(Input.GetTouch(0).position.y);
        //skip update function if touch is outside of swipezone
        if(Input.touchCount > 0 && (Input.GetTouch(0).position.y < 1150 || Input.GetTouch(0).position.y > 1525))
            return;
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            axe.transform.position = startTouchPosition;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if(endTouchPosition.x < startTouchPosition.x)
            {
                Debug.Log("User Swiped Left");
            }
            if(endTouchPosition.x > startTouchPosition.x)
            {
                Debug.Log("User Swiped Right");
                player.GetComponent<PlayerController>().Chop();
            }
            
        }
        if(Input.touchCount>0)
        {
            axe.transform.position = Input.GetTouch(0).position;
        }
        if(Input.touchCount == 0)
        {
            axe.transform.position = axeStartPosition;
           
        }
    }
}
