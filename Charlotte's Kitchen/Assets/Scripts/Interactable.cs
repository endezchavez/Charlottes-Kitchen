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

    public abstract void PerformInteraction(E_ItemType itemTypeInHand);

    /*
    public interface IInteractable
    {
        void PerfromInteraction();
    }
    */

}

