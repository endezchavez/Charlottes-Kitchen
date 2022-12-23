using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pickupable : Interactable
{

    [HideInInspector] public Hand pickupHand;
    
    [HideInInspector] public Transform originalLeftHandModel;

    [HideInInspector] public Transform originalRightHandModel;

    [HideInInspector] public GameObject leftHandPrefab;
    [HideInInspector] public GameObject rightHandPrefab;

    [SerializeField] E_ItemType itemType;

    [SerializeField] List<ItemType> hideableItems;
    [SerializeField] Vector3 heldPosition;
    [SerializeField] Vector3 heldRotation;

    [SerializeField] GameObject itemsParent;

    Outline outline;
    Hideable hidebale;

    private bool canBeUsed = true;


    protected override void Awake()
    {
        base.Awake();

        if(standPos == null)
        {
            Debug.Log(itemType);
        }

        outline = GetComponent<Outline>();
        hidebale = GetComponentInChildren<Hideable>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        EventManager.Instance.onItemConsumed += DisablePickubale;
        EventManager.Instance.onItemReset += ResetItem;
    }

    private void OnDisable()
    {
        EventManager.Instance.onItemConsumed -= DisablePickubale;
        EventManager.Instance.onItemReset -= ResetItem;

    }

    public void SetCanBeUsed(bool i)
    {
        canBeUsed = i;
    }

    public bool CanBeUsed()
    {
        return canBeUsed;
    }

    void PickupItem(Hand hand)
    {
        Transform handParent;
        GameObject itemPrefab;
        
        if (hand == Hand.LEFT)
        {
            handParent = ai.leftHandPos;
            itemPrefab = leftHandPrefab;
        }
        else
        {
            handParent = ai.rightHandPos;
            itemPrefab = rightHandPrefab;
        }

        GameObject newItem = Instantiate(itemPrefab, handParent);

        Hideable newHideable = newItem.GetComponent<Hideable>();
        if (newHideable)
            newHideable.CopyHideableData(hidebale);
        
        if(hidebale)
            hidebale.HideAllItems();


        newItem.transform.localPosition = heldPosition;
        newItem.transform.localRotation = Quaternion.Euler(heldRotation);

        if (outline != null)
        {
            outline.HideModelMesh();
        }
    }

    public void PutDownItem()
    {
        if(ai.GetItemTypesInHand().itemType == itemType)
        {
            if(ai.GetHideableInHand())
                hidebale.CopyHideableData(ai.GetHideableInHand());
            
            if (ai.HasObjectInRightHand())
            {
                Destroy(ai.GetObjectInRightHand());
            }
            if (ai.HasObjectInLeftHand())
            {
                Destroy(ai.GetObjectInLeftHand());
            }

            if (outline != null)
            {
                outline.ShowModelMesh();
            }
        }
    }

    void ResetItem(E_ItemType itemType)
    {
        if(this.itemType == itemType)
        {
            if (hidebale)
                hidebale.HideAllItems();

            if (outline)
                outline.ShowModelMesh();
        }
    }

    public override void PerformInteraction(ItemType itemTypeInHand)
    {
        if (this.enabled)
        {
            //Pickup Item
            if (!ai.IsCarryingObject())
            {
                if (pickupHand.HasFlag(Hand.LEFT) && !ai.HasObjectInLeftHand())
                {
                    PickupItem(Hand.LEFT);
                }

                if (pickupHand.HasFlag(Hand.RIGHT) && !ai.HasObjectInRightHand())
                {
                    PickupItem(Hand.RIGHT);
                }
            }
            //Drop Off Item
            else
            {
                PutDownItem();
            }
        }
        
    }

    

    public void ShowOriginalModelMesh()
    {
        outline.ShowModelMesh();
    }

    public void HideItems()
    {
        itemsParent.SetActive(false);
    }

    public void ShowItems()
    {
        itemsParent.SetActive(true);
    }

    void DisablePickubale(E_ItemType itemType)
    {
        if (this.itemType == itemType)
            this.enabled = false;
    }

    void EnablePickupable(E_ItemType itemType)
    {
        if(this.itemType == itemType)
            this.enabled = true;
    }

}
