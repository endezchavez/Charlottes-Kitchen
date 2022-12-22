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
    [SerializeField] Vector3 heldPosition;
    [SerializeField] Vector3 heldRotation;

    [SerializeField] GameObject itemsParent;

    Outline outline;
    Hideable hidebale;

    private bool canBeUsed = true;

    TagChanger tagChanger;

    protected override void Awake()
    {
        base.Awake();

        if(standPos == null)
        {
            Debug.Log(itemType);
        }

        outline = GetComponent<Outline>();
        hidebale = GetComponent<Hideable>();
        tagChanger = GetComponent<TagChanger>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        EventManager.Instance.onItemConsumed += DisablePickubale;
    }

    private void OnDisable()
    {
        EventManager.Instance.onItemConsumed -= DisablePickubale;
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
        PickupableReferencer pickupRef = newItem.AddComponent<PickupableReferencer>();

        pickupRef.pickupable = this;

        Hideable newItemHideable = newItem.GetComponent<Hideable>();

        if (hidebale && newItemHideable)
        {
            //if (hidebale.isItemsActive)
            //{
                newItemHideable.ShowSelectedHideables(hidebale);
                hidebale.HideHideableItems();
            //}
        }

        //newItem.tag = gameObject.tag;
        newItem.transform.localPosition = heldPosition;
        //newItem.transform.rotation = Quaternion.LookRotation(handParent.right, itemPrefab.transform.forward);
        newItem.transform.localRotation = Quaternion.Euler(heldRotation);

        if (outline != null)
        {
            outline.HideModelMesh();
        }

        /*
        item.parent = handParent;
        item.localPosition = Vector3.zero;

        item.rotation = Quaternion.LookRotation(handParent.right, item.forward);
        */

    }

    public void ResetItems()
    {
        if (ai.HasObjectInLeftHand() && originalLeftHandModel != null && ai.GetObjectInLeftHand().tag == originalLeftHandModel.tag)
        {
            GameObject itemInLeftHand = ai.GetObjectInLeftHand();
            Hideable hideable = itemInLeftHand.GetComponent<Hideable>();
            if (hideable && hideable.isItemsActive)
            {
                GetComponent<Hideable>().ShowHideableItems();
            }
            GameObject.Destroy(ai.GetObjectInLeftHand());
        }

        if (ai.HasObjectInRightHand() && originalRightHandModel != null && ai.GetObjectInRightHand().tag == originalRightHandModel.tag)
        {
            GameObject itemInRightHand = ai.GetObjectInRightHand();
            Hideable hideable = itemInRightHand.GetComponent<Hideable>();
            if (hideable && hideable.isItemsActive)
            {
                GetComponent<Hideable>().ShowHideableItems();
            }
            GameObject.Destroy(ai.GetObjectInRightHand());
        }

        if(outline != null)
        {
            outline.ShowModelMesh();
        }

    }

    public override void PerformInteraction(E_ItemType itemTypeInHand)
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
                ResetItems();
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
