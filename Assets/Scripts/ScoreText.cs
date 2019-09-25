using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text text;
    string scoreText;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        scoreText = text.text;
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        text.text = scoreText + score;
    }
}
