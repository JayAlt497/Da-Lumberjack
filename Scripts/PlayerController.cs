using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

//////////////////////////////
// Written by: Jayden Alton //
// Documented by Chat GPT   //
// Last Modified: 2/14/2023 //
//////////////////////////////

// Class that controls the player's movements and interactions with the game world
public class PlayerController : MonoBehaviour
{
    // References to other game objects and components
    private GameObject currTree; // Reference to the tree the player is currently close to
    public GameObject EventSystem; // Reference to the game's EventSystem
    public TextMeshProUGUI scoreText; // Reference to the text UI element that displays the player's score
    public Animator anim; // Reference to the player's animator component

    // Movement
    public float speed; // Speed of the player
    public float jump; // Jump height of the player
    float moveVelocity; // Current movement velocity of the player

    // Temperature Variables
    private const float FREEZE_TEMP = 32.0f; // The temperature at which the player will freeze
    private float internalTemp; // The player's internal temperature
    private float externalTemp; // The player's external temperature
    private float thermalProtection; // The amount of thermal protection the player has
    private float timeSinceTempDrop; // The time since the player's external temperature last dropped

    // Grounded Vars
    bool inRange = false; // Whether the player is in range to chop a tree
    public int damage; // Damage dealt to trees when chopped
    int score = 0; // Current score of the player

    // Start is called before the first frame update
    private void Start()
    {
        internalTemp = 97.0f;
        externalTemp = 97.0f;
        PlayerPrefs.GetFloat("thermalProtection", thermalProtection);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTempDrop += Time.deltaTime;
        if (timeSinceTempDrop > 1)
        {
            timeSinceTempDrop = 0;
            externalTemp--;
        }

        // Check if the player has frozen to death
        if (internalTemp < FREEZE_TEMP)
        {
            // Add score
            PlayerPrefs.SetInt("currency", (PlayerPrefs.GetInt("currency", 0) + score)); 
            EventSystem.GetComponent<MenuSystemScript>().LoadGameOver();
        }

        // Update the score text
        scoreText.GetComponent<Score>().updateScore(score);

        // Update the player's animation speed
        anim.SetFloat("Speed", Mathf.Abs(moveVelocity));

        // Update the player's movement
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Adjust the player's internal temperature based on the external temperature and thermal protection
    public void playerTempAdjust()
    {
        float tempDiff = internalTemp - externalTemp;
        internalTemp = externalTemp - tempDiff / thermalProtection;
    }

    // Move the player to the left
    public void MoveLeft()
    {
        moveVelocity = -speed;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    // Move the player to the right
    public void MoveRight()
    {
        moveVelocity = speed;
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    // Damages the tree player is close enough too
    public void Chop()
    {
        if (!inRange || currTree == null)
            return;

        currTree.GetComponent<Tree>().treeHP -= damage;

        // Check if the tree has been chopped down
        if (currTree.GetComponent<Tree>().treeHP <= 0)
        {
            currTree.GetComponent<Tree>().Respawn(score);
            scoring();
        }
    }

    // Add score for chopping down a tree
    public void scoring()
    {
        score++;

        // Check if the player has beaten their high score
        if (PlayerPrefs.GetInt("highScore") <= score)
            PlayerPrefs.SetInt("highScore", score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            inRange = true;
            moveVelocity = 0;
            currTree = collision.GetComponentInParent<Tree>().gameObject;
        }

        if (collision.gameObject.tag == "Cabin")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            inRange = false;
            currTree = null;
        }
    }
}
