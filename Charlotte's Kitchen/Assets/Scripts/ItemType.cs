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
    PILE_OF_CLOTHES,
    DRYING_CLOTHES

}

public class ItemType : MonoBehaviour
{
    public E_ItemType itemType;
}
