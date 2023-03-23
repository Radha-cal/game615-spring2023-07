using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static float playerScore;
    public static float enemyScore;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;
    public TextMeshProUGUI timerText;
    //GameObject tile;

    public float levelTimer = 60;
    public float levelTimerAlt;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        enemyScore = 0;
        playerScoreText.gameObject.SetActive(false);
        enemyScoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer = levelTimer - Time.deltaTime;
        levelTimerAlt = Mathf.Round(levelTimer);
        timerText.text = levelTimerAlt.ToString();
        if (levelTimer <= 0)
        {
            foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
            {
                if (tile.GetComponent<Renderer>().material.color == Color.cyan)
                {
                    playerScore++;
                }

                if (tile.GetComponent<Renderer>().material.color == Color.magenta)
                {
                    enemyScore++;
                }
            }
            
            levelTimer = 60;
            playerScoreText.gameObject.SetActive(true);
            enemyScoreText.gameObject.SetActive(true);
            timerText.gameObject.SetActive(false);
            playerScoreText.text = "Player Score: " + playerScore.ToString();
            enemyScoreText.text = "Enemy Score: " + enemyScore.ToString();
        }
    

    }
}