using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private int highScore;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.SetText("High Score: " + highScore);
    }
}
