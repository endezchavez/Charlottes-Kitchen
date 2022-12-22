using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageTween : MonoBehaviour
{
    private void OnEnable()
    {
        LeanTween.scale(gameObject, Vector3.one * 1.3f, 1f).setEasePunch();
    }

    
}
