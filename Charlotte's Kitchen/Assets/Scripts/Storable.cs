using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storable : Interactable
{
    [SerializeField] Transform[] storedItems;
    [SerializeField] Transform storageUI;
    [SerializeField] Pickupable[] pickupables;

    public override void PerformInteraction(ItemType itemTypeInHand)
    {
        ShowUI();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
    
    }

    void ShowUI()
    {
        if (!storageUI.gameObject.activeInHierarchy)
        {
            storageUI.gameObject.SetActive(true);
        }
    }


}
