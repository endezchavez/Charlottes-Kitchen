using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-10)]
public class GameManager : MonoBehaviour
{
    public GameOver gameOverScreen;
    public GameObject charlotte;

    public RectTransform canvasRect;
    public RectTransform progressBarPrefab;
    public RectTransform storageUIPrefab;


    //public Plant[] plants;

    [SerializeField] LayerMask whatIsInteractable;

    [HideInInspector]
    public CharlotteAI charlotteAI;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int tasksCompleted;
    [HideInInspector]
    public int numPlantsWatered;

    [HideInInspector]
    public bool isGameOver;

    Ray ray;
    RaycastHit hit;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        charlotteAI = charlotte.GetComponent<CharlotteAI>();

    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        charlotteAI.enabled = false;
        gameOverScreen.SetValues();
        isGameOver = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetPlants()
    {
        //foreach(Plant plant in plants)
        //{
        //    plant.ResetTask();
        //    numPlantsWatered = 0;
        //}
    }



}
