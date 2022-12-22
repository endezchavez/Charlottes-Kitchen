using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTimer : MonoBehaviour
{
    public float roundTime = 2 * 60;

    public GameObject gameOverScreen; 

    private float timeRemaining;
    private bool keepTiming = true;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        timeRemaining = roundTime;
    }

    void Update()
    {
        if (keepTiming)
        {
            UpdateTime();
        }
    }

    void UpdateTime()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            text.SetText(TimeToString(timeRemaining));

        }
        else
        {
            timeRemaining = 0f;
            keepTiming = false;
            StopTimer();
        }
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        //string seconds = (t % 60).ToString("f2");
        string seconds = (t % 60).ToString("f0");
        return minutes + ":" + seconds;
    }

    void StopTimer()
    {
        gameOverScreen.SetActive(true);
        LeanTween.scale(gameOverScreen, Vector3.one, 1f).setFrom(Vector3.zero);
        GameManager.Instance.GameOver();
    }
}
