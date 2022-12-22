using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        EventManager.Instance.onScoreUpdated += UpdateScore;
    }

    public void UpdateScore()
    {
        text.SetText("Score: " + GameManager.Instance.score);
        LeanTween.scale(gameObject, new Vector3(1.3f, 1.3f, 0f), 0.5f).setOnComplete(ScaleDown);
    }

    void ScaleDown()
    {
        LeanTween.scale(gameObject, Vector3.one, 0.5f);
    }


}
