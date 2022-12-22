using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Transform progressBarPos;
    
    float timerLength;

    private float timeRemaining;

    bool keepTiming;

    private RectTransform progressBar;
    private Image progressBarImg;
    private ITimedTask timedTask;

    private bool playSound = true;

    [HideInInspector]
    public bool isTimerFinished = false;
    [HideInInspector]
    public bool isTimerRunning = false;
    [HideInInspector]
    public bool isTimerPaused = false;

    private void Awake()
    {
       
    }

    private void Start()
    {
        progressBar = Instantiate(GameManager.Instance.progressBarPrefab);
        progressBar.SetParent(progressBarPos);
        progressBar.localPosition = Vector3.zero;
        progressBarImg = progressBar.GetChild(0).GetChild(0).GetComponent<Image>();
        progressBar.gameObject.SetActive(false);

        timeRemaining = timerLength;
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
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            progressBarImg.fillAmount = Mathf.InverseLerp(0f, timerLength, timeRemaining);

        }
        else
        {
            timeRemaining = 0f;
            StopTimer();
            //timedTask.TaskCompleted();
        }
    }

    public void StopTimer()
    {
        progressBar.gameObject.SetActive(false);

        keepTiming = false;
        isTimerFinished = true;
        isTimerRunning = false;
        
    }

    public void PauseTimer()
    {
        keepTiming = false;
        isTimerRunning = false;
        isTimerPaused = true;
        
    }

    public void ResumeTimer()
    {
        keepTiming = true;
        isTimerRunning = true;
        isTimerPaused = false;
    }

    public void StartTimer()
    {
        Debug.Log("Timer Started");
        progressBar.gameObject.SetActive(true);
        keepTiming = true;
        isTimerFinished = false;
        isTimerRunning = true;
        timeRemaining = timerLength;
     
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds;
    }

    public void SetTimerLength(float length)
    {
        timerLength = length;
    }

    public void SetProgressBar(RectTransform rect)
    {
        progressBar = rect;
        progressBarImg = progressBar.GetChild(0).GetComponent<Image>();
    }

    public void SetPlaySound(bool i)
    {
        playSound = i;
    }


}
