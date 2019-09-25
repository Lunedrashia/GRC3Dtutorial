using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    [SerializeField] GameObject[] pins;
    [SerializeField] Transform[] pinsInitial;
    [SerializeField] GameObject pinPrefab;
    [SerializeField] ScoreText scoreText;
    int pinAmount;
    int pinLeft;
    int pinScore = 100;
    int scoreMultiplier = 1;
    int timeMultiplier = 0;

    // Start is called before the first frame update
    void Start()
    {
        pinAmount = pinsInitial.Length;
        pinLeft = pinAmount;
        SpawnNewPins();
    }

    public void ResetState(int t)
    {
        if(pinLeft == 0 && t == 0)
        {
            scoreMultiplier = 2;
            timeMultiplier = 2;
        }
        else if (pinLeft == 0 && t == 1)
        {
            scoreMultiplier = 2;
            timeMultiplier = 1;
        }
        else
        {
            timeMultiplier = 0;
            scoreMultiplier = 1;
        }
        SpawnNewPins();
    }

    void SpawnNewPins()
    {
        if(pins.Length != 0)
        {
            foreach(GameObject pin in pins)
            {
                Destroy(pin);
            }
        }
        pins = new GameObject[pinAmount];
        for(int i = 0; i < pinAmount; i++)
        {
            GameObject newPin = Instantiate(pinPrefab, pinsInitial[i].position, pinsInitial[i].rotation, transform);
            newPin.transform.localScale = pinsInitial[i].localScale;
            pins[i] = newPin;
        }
        pinLeft = pinAmount;
    }

    public int RelocateLeftPins(int t)
    {
        for(int i = 0; i < pinAmount; i++)
        {
            if(pins[i] == null || pins[i].transform.rotation.x == 0)
            {
                continue;
            }
            RemovePin(pins[i]);
        }
        if(pinLeft == 0 || t == 1)
        {
            ResetState(t);
            return 0;
        }
        if (timeMultiplier > 0)
        {
            timeMultiplier--;
        }
        if (timeMultiplier == 0)
        {
            scoreMultiplier = 1;
        }
        return 1;
    }

    public void RemovePin(GameObject p)
    {
        Destroy(p);
        pinLeft--;
        GameManager.instance.AddScore(pinScore * scoreMultiplier);
    }
}
