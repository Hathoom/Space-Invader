using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;

    public TextMeshProUGUI highScoreText;

    private float currentScore = 0f;
    private float highScore = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //set highScore to recorded high score.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(float score)
    {
        currentScore += score;

        if (currentScore > highScore)
        {
            highScore = currentScore;

            //set high score text
            setProperScoreText(1, highScore);
            PlayerPrefs.SetFloat("highScore", highScore);
        }

        //set current score text
        // 5 digits 00000
        setProperScoreText(0, currentScore);
    }

    public void setHighScore(float score)
    {
        highScore = score;
        setProperScoreText(1, highScore);
    }

    private void setProperScoreText(int flag, float score)
    {
        string scoretext = "";

        if (score == 0f)
        {
            scoretext = "00000";
        }
        //system to set the score in 5 digits
        //ex: 00200
        else 
        {
            for (float i = score; i < 9999; i = i * 10f)
            {
                scoretext = scoretext + "0";
            }
        }
        

        // set current score
        if (flag == 0)
        {
            currentScoreText.text = scoretext + score.ToString();
        }
        // set high score
        else if (flag == 1)
        {
            highScoreText.text = scoretext + score.ToString();
        }
    }
}
