using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharlotteAI : MonoBehaviour
{
    public float rotationSpeed;

    public Transform leftHandPos;
    public Transform rightHandPos;
    public Transform feetPos;

    private NavMeshAgent navMeshAgent;
    private Vector3 destination;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public bool isWalking;


    private Quaternion lookRotation;
    private Vector3 lookDir;
    private Vector3 dir;

    private bool isFollowingTarget = false;

    Rigidbody rb;

    Interactable[] lastClickedInteractables;
    //Destination lastClickedDestination;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        destination = Vector3.positiveInfinity;
    }

    private void Update()
    {
        if (InputManager.Instance.PlayerClickedInteractableThisFrame())
        {
            lastClickedInteractables = InputManager.Instance.GetLastClickedInteractables();
            destination = lastClickedInteractables[0].standPos;
            lookDir = lastClickedInteractables[0].lookDir;
            //navMeshAgent.destination = destination;
            isFollowingTarget = true;
            isWalking = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFollowingTarget)
        {
            dir = (destination - transform.position).normalized;

            if (Vector3.Distance(transform.position, destination) > 0.1f)
            {
                rb.MovePosition(transform.position + dir * Time.deltaTime * 1f);
                //animator.SetBool("isWalking", true);
                transform.LookAt(destination);
            }
            else
            {
                isWalking = false;

                lookRotation = Quaternion.LookRotation(lookDir);

                //rotate us over time according to speed until we are in the required rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (Quaternion.Angle(transform.rotation, lookRotation) <= 5f)
                {

                    //IInteractable interactable = InputManager.Instance.GetLastClickedIInteractable();
                    //Interactable interactable = InputManager.Instance.GetLastClickedInteractable();
                    ITimedTask timedTask = InputManager.Instance.GetLastClickedInteractableTransform().GetComponent<ITimedTask>();

                    if (timedTask != null)
                    {
                        if (timedTask.IsTaskInProgress())
                        {
                            return;
                        }
                    }

                    //IInteractable interactable = (IInteractable)lastClickedInteractable;
                    //interactable.PerformInteraction();
                    /*
                    foreach(Interactable i in lastClickedDestination.interactables)
                    {
                        IInteractable x = (IInteractable)i;
                        x.PerformInteraction();
                    }
                    */
                    foreach(Interactable interactable in lastClickedInteractables)
                    {
                        interactable.PerformInteraction(GetItemTypesInHand());
                    }

                    //animator.SetBool("isWalking", false);
                    isFollowingTarget = false;
                }
            }
        }
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    E_ItemType GetItemTypesInHand()
    {
        if (HasObjectInRightHand())
        {
            return GetObjectInRightHand().GetComponent<ItemType>().itemType;
        }else if (HasObjectInLeftHand())
        {
            return GetObjectInLeftHand().GetComponent<ItemType>().itemType;
        }
        else
        {
            return E_ItemType.NONE;
        }

    }

    public GameObject GetObjectInLeftHand()
    {
        return leftHandPos.GetChild(0).gameObject;
    }

    public GameObject GetObjectInRightHand()
    {
        return rightHandPos.GetChild(0).gameObject;
    }

    public Pickupable GetPickupableInRightHand()
    {
        return rightHandPos.GetChild(0).GetComponent<Pickupable>();
    }

    public Pickupable GetPickupableInLeftHand()
    {
        return leftHandPos.GetChild(0).GetComponent<Pickupable>();
    }

    public bool HasObjectInLeftHand()
    {
        return leftHandPos.childCount != 0;
    }

    public bool HasObjectInRightHand()
    {
        return rightHandPos.childCount != 0;
    }

    public bool IsCarryingObject()
    {
        return (rightHandPos.childCount != 0 || leftHandPos.childCount != 0);
    }

    /*
    public IInteractable GetInteractableInLeftHand()
    {
        if (!HasObjectInLeftHand())
        {
            return null;
        }


        IInteractable interactable = GetObjectInLeftHand().GetComponent<IInteractable>();
        if(interactable == null)
        {
            return null;
        }
        return interactable;
    }

    public IInteractable GetInteractableInRightHand()
    {
        if (!HasObjectInRightHand())
        {
            return null;
        }

        IInteractable interactable = GetObjectInRightHand().GetComponent<IInteractable>();
        if (interactable == null)
        {
            return null;
        }
        return interactable;
    }
    */

    
    public void DestroyItemsInHand()
    {
        if (HasObjectInRightHand())
        {
            Destroy(GetObjectInRightHand());
        }

        if (HasObjectInLeftHand())
        {
            Destroy(GetObjectInLeftHand());
        }
    }


    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }

}
