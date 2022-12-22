using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform tasksParent;

    public RectTransform progressBarPrefab;
    public Transform progressBarParent;
    public RectTransform canvasRect;

    public Timer choppingBoardTimer;
    public Timer fryingPanTimer;
    public Timer washingMachineTimer;
    public Timer microwaveTimer;
    public Timer dryingRackTimer;
    public Timer bowlTimer;
    public Timer toasterTimer;
    public Timer plant1Timer;
    public Timer plant2Timer;
    public Timer plant3Timer;

    public Transform choppingBoardProgressTransform;
    public Transform fryingPanProgressTransform;
    public Transform washingMachineProgressTransform;
    public Transform microwaveProgressTransform;
    public Transform dryingRackProgressTransform;
    public Transform bowlProgressTransform;
    public Transform toasterProgressTransform;
    public Transform plant1ProgressTransform;
    public Transform plant2ProgressTransform;
    public Transform plant3ProgressTransform;

    private RectTransform choppingBoardRect;
    private RectTransform fryingPanRect;
    private RectTransform washingMachineRect;
    private RectTransform microwaveRect;
    private RectTransform dryingRackRect;
    private RectTransform bowlRect;
    private RectTransform toasterRect;
    private RectTransform plant1Rect;
    private RectTransform plant2Rect;
    private RectTransform plant3Rect;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;

        /*
        choppingBoardRect = Instantiate(progressBarPrefab);
        choppingBoardRect.SetParent(progressBarParent, false);
        fryingPanRect = Instantiate(progressBarPrefab);
        fryingPanRect.SetParent(progressBarParent, false);
        washingMachineRect = Instantiate(progressBarPrefab);
        washingMachineRect.SetParent(progressBarParent, false);
        microwaveRect = Instantiate(progressBarPrefab);
        microwaveRect.SetParent(progressBarParent, false);
        dryingRackRect = Instantiate(progressBarPrefab);
        dryingRackRect.SetParent(progressBarParent, false);
        bowlRect = Instantiate(progressBarPrefab);
        bowlRect.SetParent(progressBarParent, false);
        toasterRect = Instantiate(progressBarPrefab);
        toasterRect.SetParent(progressBarParent, false);
        plant1Rect = Instantiate(progressBarPrefab);
        plant1Rect.SetParent(progressBarParent, false);
        plant2Rect = Instantiate(progressBarPrefab);
        plant2Rect.SetParent(progressBarParent, false);
        plant3Rect = Instantiate(progressBarPrefab);
        plant3Rect.SetParent(progressBarParent, false);

        SetProgressBarPosition(choppingBoardRect, choppingBoardProgressTransform.position);
        SetProgressBarPosition(fryingPanRect, fryingPanProgressTransform.position);
        SetProgressBarPosition(washingMachineRect, washingMachineProgressTransform.position);
        SetProgressBarPosition(microwaveRect, microwaveProgressTransform.position);
        SetProgressBarPosition(dryingRackRect, dryingRackProgressTransform.position);
        SetProgressBarPosition(bowlRect, bowlProgressTransform.position);
        SetProgressBarPosition(toasterRect, toasterProgressTransform.position);
        SetProgressBarPosition(plant1Rect, plant1ProgressTransform.position);
        SetProgressBarPosition(plant2Rect, plant2ProgressTransform.position);
        SetProgressBarPosition(plant3Rect, plant3ProgressTransform.position);

        choppingBoardTimer.SetProgressBar(choppingBoardRect);
        fryingPanTimer.SetProgressBar(fryingPanRect);
        washingMachineTimer.SetProgressBar(washingMachineRect);
        microwaveTimer.SetProgressBar(microwaveRect);
        dryingRackTimer.SetProgressBar(dryingRackRect);
        bowlTimer.SetProgressBar(bowlRect);
        toasterTimer.SetProgressBar(toasterRect);
        plant1Timer.SetProgressBar(plant1Rect);
        plant2Timer.SetProgressBar(plant2Rect);
        plant3Timer.SetProgressBar(plant3Rect);
        */
    }

   

    void SetProgressBarPosition(RectTransform rect, Vector3 pos)
    {
        Vector2 viewPortPos = cam.WorldToViewportPoint(pos);
        Vector2 worldObjScreenPos = new Vector2(
        ((viewPortPos.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
        ((viewPortPos.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

        rect.anchoredPosition = worldObjScreenPos;
    }

    

}
