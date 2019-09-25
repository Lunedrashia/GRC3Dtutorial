using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] PinManager pinManager;
    [SerializeField] BallController ball;
    [SerializeField] ScoreText scoreText;
    [SerializeField] CameraFollowing mainCamera;
    int score = 0;
    int t = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            t = pinManager.RelocateLeftPins(t);
            ball.gameObject.SetActive(true);
            ball.ResetState();
            mainCamera.ResetPosition();
            mainCamera.SetFollow(true);
        }
    }

    public void AddScore(int s)
    {
        score += s;
        scoreText.UpdateScore(score);
    }
}
