using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_ItemType
{
    NONE,
    BOWL,
    BOWL_WITH_WHISKED_EGGS,
    PLATE,
    PLATE_WITH_TOAST,
    PLATE_WITH_SCRAMBLED_EGGS,
    BREAD,
    TOAST,
    RICE,
    FRYING_PAN,
    FRYING_PAN_WITH_COOKED_EGGS,
    WATERING_CAN,
    EGG,
    CLOTHES,
    BASKET,
    PILE_OF_CLOTHES

}

public class ItemType : MonoBehaviour
{
    public E_ItemType itemType;

    public List<ItemType> hideableItems;

    private void OnEnable()
    {
        EventManager.Instance.onItemShowen += ShowItem;
        EventManager.Instance.onItemHidden += HideItem;
    }

    private void OnDisable()
    {
        EventManager.Instance.onItemShowen -= ShowItem;
        EventManager.Instance.onItemHidden -= HideItem;
    }

    void ShowItem(E_ItemType itemType)
    {
        foreach(ItemType item in hideableItems)
        {
            if (item.itemType == itemType)
                item.gameObject.SetActive(true);
        }
    }

    void HideItem(E_ItemType itemType)
    {
        foreach (ItemType item in hideableItems)
        {
            if (item.itemType == itemType)
                item.gameObject.SetActive(false);
        }
    }

}
