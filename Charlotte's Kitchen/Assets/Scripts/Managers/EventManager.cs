using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class EventManager : MonoBehaviour
{
    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public event Action onCurryServed;
    public void CurryServed()
    {
        if(onCurryServed != null)
        {
            onCurryServed();
        }
    }

    public event Action onEggsServed;
    public void EggsServed()
    {
        if (onEggsServed != null)
        {
            onEggsServed();
        }
    }

    public event Action onWashingCompleted;
    public void WashingCompleted()
    {
        if (onWashingCompleted != null)
        {
            onWashingCompleted();
        }
    }

    public event Action onWateringCompleted;
    public void WateringCompleted()
    {
        if (onWateringCompleted != null)
        {
            onWateringCompleted();
        }
    }

    public event Action onScoreUpdated;
    public void ScoreUpdated()
    {
        if (onScoreUpdated != null)
        {
            onScoreUpdated();
        }
    }

    public event Action<E_ItemType> onItemConsumed;
    public void ItemConsumed(E_ItemType itemType)
    {
        if (onItemConsumed != null)
        {
            onItemConsumed(itemType);
        }
    }

    public event Action<E_ItemType> onItemShowen;
    public void ItemShowen(E_ItemType itemType)
    {
        if (onItemShowen != null)
        {
            onItemShowen(itemType);
        }
    }

    public event Action<E_ItemType> onItemHidden;
    public void ItemHidden(E_ItemType itemType)
    {
        if (onItemHidden != null)
        {
            onItemHidden(itemType);
        }
    }

    public event Action<E_ItemType> onItemReset;
    public void ItemReset(E_ItemType itemType)
    {
        if (onItemReset != null)
        {
            onItemReset(itemType);
        }
    }

}
