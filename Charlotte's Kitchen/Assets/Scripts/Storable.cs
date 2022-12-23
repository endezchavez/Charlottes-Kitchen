using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storable : Interactable
{
    [SerializeField] StorableItem[] storedItems;
    [SerializeField] Transform storageUI;

    public override void PerformInteraction(ItemType itemTypeInHand)
    {
        ShowUI();

    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    void ShowUI()
    {
        if (!ai.IsCarryingObject())
        {
            if (!storageUI.gameObject.activeInHierarchy)
            {
                storageUI.gameObject.SetActive(true);
            }
        }
        
    }
    
}
