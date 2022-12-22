using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    private void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 0f), 2f).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
    }
}
