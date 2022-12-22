using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToScreen : MonoBehaviour
{
    public Transform position;
    public RectTransform canvasRect;

    private Camera cam;
    private RectTransform rect;

    private void Awake()
    {
        cam = Camera.main;
        rect = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetPosition();
    }

    void SetPosition()
    {
        Vector2 viewPortPos = cam.WorldToViewportPoint(position.position);
        Vector2 worldObjScreenPos = new Vector2(
        ((viewPortPos.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
        ((viewPortPos.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

        rect.anchoredPosition = worldObjScreenPos;
    }
}
