using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    public ItemType[] itemsToHide;

    public void ShowItem(E_ItemType itemType)
    {
        foreach(ItemType item in itemsToHide)
        {
            if(item.itemType == itemType)
            {
                item.gameObject.SetActive(true);
            }
        }
    }

    public void HideAllItems()
    {
        foreach(ItemType item in itemsToHide)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void CopyHideableData(Hideable hideable)
    {
        foreach (ItemType otherItem in hideable.itemsToHide)
        {
            foreach (ItemType item in itemsToHide)
            {
                if (otherItem.itemType == item.itemType)
                {
                    item.gameObject.SetActive(otherItem.isActiveAndEnabled);
                }
            }
        }
    }

    public bool IsItemEnabled(E_ItemType itemType)
    {
        foreach(ItemType item in itemsToHide)
        {
            if(item.itemType == itemType)
            {
                return item.isActiveAndEnabled;
            }
        }
        return false;
    }

}
