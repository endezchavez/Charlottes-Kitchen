using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    [SerializeField] GameObject[] itemsToHide;

    [HideInInspector] public bool isItemsActive;

    public void ShowHideableItems()
    {
        foreach(GameObject item in itemsToHide)
        {
            item.SetActive(true);
        }
        isItemsActive = true;
    }

    public void HideHideableItems()
    {
        foreach (GameObject item in itemsToHide)
        {
            item.SetActive(false);
        }
        isItemsActive = false;

    }

    public void ShowSelectedHideables(Hideable hideable)
    {
        foreach(GameObject item in itemsToHide)
        {
            foreach(GameObject otherItem in hideable.itemsToHide)
            {
                if(item.tag == otherItem.tag)
                {
                    if (otherItem.activeInHierarchy)
                    {
                        item.SetActive(true);
                    }
                }
            }
        }
    }

    public void ShowHideableItems(string tag)
    {
        foreach (GameObject item in itemsToHide)
        {
            if(item.tag == tag)
            {
                item.SetActive(true);
            }
        }
    }

}
