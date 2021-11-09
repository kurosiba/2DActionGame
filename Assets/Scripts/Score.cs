using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private int oldScore;

    void Start()
    {
        scoreText = GetComponent<Text>();
        
        if(scoreText != null && gManager.instance != null) {
            scoreText.text = "score " + gManager.instance.score.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null && gManager.instance != null) {
           if(oldScore != gManager.instance.score) {
                scoreText.text = "score" + " " + gManager.instance.score.ToString();
                oldScore = gManager.instance.score;
            }
        }

    }
}
