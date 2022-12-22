using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tasksText;

    public void SetValues()
    {
        scoreText.SetText("Score: " + GameManager.Instance.score);
        tasksText.SetText("Tasks Completed: " + GameManager.Instance.tasksCompleted);
    }
}
