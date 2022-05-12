using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        string highScoreName = MainManager1.Instance.highScoreName;
        int highScore = MainManager1.Instance.highScore;
        if (highScoreName != "" && highScore > 0)
        {
            highScoreText.text = "High Score : " + highScoreName + " : " + highScore;
        }
    }

    public void UpdateScore(string name, int score)
    {
        highScoreText.text = "High Score : " + name + " : " + score;
    }
}
