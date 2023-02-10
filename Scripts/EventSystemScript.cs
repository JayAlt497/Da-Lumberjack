using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////////////////
// Written by: Jayden Alton
// Associate writing: 
// Last Modified: 1/22/2023
////////////////////////////

public class EventSystemScript : MonoBehaviour
{
    public int freezeTime;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //amount of time since scene loaded > set freeze time in unity
        if(Time.timeSinceLevelLoad > freezeTime)
        {
            LoadGameOver();
        }
    }

    //Loads the Game scene
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Loads GameOver Screen
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

