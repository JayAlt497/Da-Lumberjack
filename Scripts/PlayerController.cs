using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

///////////////////////////
// Written by: Jayden Alton
// Associate writing: 
// Last Modified: 1/25/2023
////////////////////////////

public class PlayerController : MonoBehaviour
{
    private GameObject currTree;
    public GameObject EventSystem;
    public TextMeshProUGUI scoreText;
    public Animator anim;

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;

    //Grounded Vars
    bool grounded = true;

    bool inRange = false;
    public int damage;
    int score = 0;

    void Update()
    {
        /*
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                grounded = false;
            }
        }
        */
        anim.SetFloat("Speed", Mathf.Abs(moveVelocity));
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        
    }
    public void MoveLeft()
    {
        moveVelocity = -speed;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void MoveRight()
    {
        moveVelocity = speed;
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    //damages the tree player is close enough too
    public void Chop()
    {
        if (!inRange || currTree == null)
            return;
        currTree.GetComponent<Tree>().treeHP -= damage;
        if(currTree.GetComponent<Tree>().treeHP <= 0)
        {
            currTree.GetComponent<Tree>().Respawn(score);
            scoring();
        }
    }
    public void scoring() {
        score++;
        scoreText.GetComponent<Score>().updateScore(score);
        if (PlayerPrefs.GetInt("highScore") <= score)
            PlayerPrefs.SetInt("highScore", score); 
    }
    //Check if Grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player Collides with tree
        if(collision.gameObject.tag == "Tree")
        {
            inRange = true;
            moveVelocity = 0;
            currTree = collision.GetComponentInParent<Tree>().gameObject; //set currentTree to the tree collided with
        }
        //Player collides with cabin door
        if (collision.gameObject.tag == "Cabin")
        {
            Debug.Log("Collision");
            SceneManager.LoadScene("Menu");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Player uncollides with Tree
        if (collision.gameObject.tag == "Tree")
        {
            inRange = false;
            currTree = null;
        }
    }

}
