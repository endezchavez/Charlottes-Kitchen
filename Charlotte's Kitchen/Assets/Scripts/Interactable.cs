using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public abstract class Interactable : MonoBehaviour
{
    public Transform standTransform;

    [HideInInspector]
    public Vector3 standPos, lookDir;

    [HideInInspector]
    public CharlotteAI ai;

    protected virtual void Awake()
    {
        standPos = standTransform.position;
        lookDir = standTransform.forward;
    }

    protected virtual void Start()
    {
        ai = GameManager.Instance.charlotteAI;
    }

    public abstract void PerformInteraction(ItemType itemTypeInHand);

    /*
    public interface IInteractable
    {
        void PerfromInteraction();
    }
    */

    public void GivePlayerItem(StorableItem item)
    {
        if (!ai.IsCarryingObject())
        {

            if (item.pickupHand == Hand.RIGHT || item.pickupHand == Hand.BOTH)
            {
                GameObject newItem = Instantiate(item.gameObject, ai.rightHandPos);

                newItem.transform.localPosition = Vector3.zero;
            }
            if (item.pickupHand == Hand.LEFT || item.pickupHand == Hand.BOTH)
            {
                GameObject newItem = Instantiate(item.gameObject, ai.leftHandPos);

                newItem.transform.localPosition = Vector3.zero;
            }
        }

    }
}

