using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskGenerator : MonoBehaviour
{
    public AudioClip[] audioClips;

    public GameObject taskPrefab;

    public TaskData[] tasks;

    private AudioSource source;

    public int curryScore;
    public int eggScore;
    public int washingScore;
    public int wateringScore;

    private int randTime;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    private void Start()
    {
        EventManager.Instance.onCurryServed += OnCurryServed;
        EventManager.Instance.onEggsServed += OnEggsServed;
        EventManager.Instance.onWashingCompleted += OnWashCompleted;
        EventManager.Instance.onWateringCompleted += OnWateringCompleted;

        GenerateTask();
        StartCoroutine(AddTaskTimer());
    }

    public void GenerateTask()
    {
        bool succesful = false;
        int maxTries = 10;
        int tries = 0;
        TaskData taskData;
        while (!succesful)
        {
            taskData = tasks[Random.Range(0, tasks.Length)];
            if (!this.transform.Find(taskData.name))
            {
                succesful = true;
                GameObject newTask = Instantiate(taskPrefab, this.transform);
                newTask.name = taskData.name;
                TextMeshProUGUI text = newTask.transform.Find("Title").GetComponent<TextMeshProUGUI>();
                text.SetText(taskData.description);
            }
            tries++;
            if(tries >= maxTries)
            {
                return;
            }

        }
    }

    public void OnCurryServed()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        Transform t = transform.Find("Curry");
        if(t == null)
        {
            return;
        }
        LeanTween.moveX(t.gameObject, -200f, 1f).setEaseInBack().setDestroyOnComplete(true);
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
        source.Play();
        GameManager.Instance.score += curryScore;
        GameManager.Instance.tasksCompleted++;
        EventManager.Instance.ScoreUpdated();

    }

    public void OnEggsServed()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        Transform t = transform.Find("Eggs");
        if (t == null)
        {
            return;
        }
        LeanTween.moveX(t.gameObject, -200f, 1f).setEaseInBack().setDestroyOnComplete(true);
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
        source.Play();
        GameManager.Instance.score += eggScore;
        GameManager.Instance.tasksCompleted++;
        EventManager.Instance.ScoreUpdated();


    }

    public void OnWashCompleted()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        Transform t = transform.Find("Washing");
        if (t == null)
        {
            return;
        }
        LeanTween.moveX(t.gameObject, -200f, 1f).setEaseInBack().setDestroyOnComplete(true);
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
        source.Play();
        GameManager.Instance.score += washingScore;
        GameManager.Instance.tasksCompleted++;
        EventManager.Instance.ScoreUpdated();
    }

    public void OnWateringCompleted()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        Transform t = transform.Find("Watering");
        if (t == null)
        {
            return;
        }
        LeanTween.moveX(t.gameObject, -200f, 1f).setEaseInBack().setDestroyOnComplete(true);
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
        source.Play();
        GameManager.Instance.score += washingScore;
        GameManager.Instance.tasksCompleted++;
        EventManager.Instance.ScoreUpdated();
    }

    IEnumerator AddTaskTimer()
    {
        while (!GameManager.Instance.isGameOver)
        {
            randTime = Random.Range(3, 6) * 5;
            yield return new WaitForSeconds(randTime);
            GenerateTask();
        }
    }
}

[System.Serializable]
public struct TaskData
{
    public string name;
    public string description;

    public TaskData(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
}
