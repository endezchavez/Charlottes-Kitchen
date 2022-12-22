using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public LayerMask whatIsInteractable;

    private static InputManager _instance;

    private InputMaster controls;
    private Camera cam;
    private RaycastHit hit;

    private Interactable[] lastClickedInteractables;
    //private Interactable lastClickedInteractable;
    private Transform lastClickedInteractableTransform;

    private Destination lastClickedDestination;

    [HideInInspector] public bool isMouseDown;
    [HideInInspector] public bool isMouseMiddleDown;


    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        controls = new InputMaster();
        cam = Camera.main;

    }

    public bool PlayerClickedThisFrame()
    {
        return controls.Player.MouseClick.triggered;
    }

    public bool PlayerClickedMiddleMouseThisFrame()
    {
        return controls.Player.MouseWheelClick.triggered;
    }

    public Vector2 GetMousePos()
    {
        return controls.Player.MousePos.ReadValue<Vector2>();
    }

    public bool PlayerClickedInteractableThisFrame()
    {
        if (!PlayerClickedThisFrame())
        {
            return false;
        }


        Vector2 mousePos = GetMousePos();
        Ray ray = cam.ScreenPointToRay(mousePos);
        bool didClickInteractable = Physics.Raycast(ray, out hit, Mathf.Infinity, whatIsInteractable);
        if (didClickInteractable)
        {
            lastClickedInteractableTransform = hit.transform;
            //lastClickedInteractable = hit.transform.gameObject.GetComponent<IInteractable>();
            lastClickedInteractables = hit.transform.gameObject.GetComponents<Interactable>();
            lastClickedDestination = hit.transform.gameObject.GetComponent<Destination>();

            if (lastClickedInteractables == null)
            {
                lastClickedInteractableTransform = hit.transform.parent;
                lastClickedInteractables = hit.transform.parent.gameObject.GetComponents<Interactable>();
            }
        }

        return didClickInteractable;
    }

    //public Vector3 GetLastClickedInteractableStandPos()
    //{
    //    return lastClickedInteractableTransform.GetComponent<StandPos>().GetStandPos();
    //}

    public Interactable[] GetLastClickedInteractables()
    {
        return lastClickedInteractables;
    }

    public Destination GetLastClickedDestination()
    {
        return lastClickedDestination;
    }

    public Transform GetLastClickedInteractableTransform()
    {
        return lastClickedInteractableTransform;
    }

    public float GetMouseScrollY()
    {
        return controls.Player.MouseScroll.ReadValue<float>();
    }


    private void OnEnable()
    {
        controls.Enable();

        controls.Player.MouseClick.performed += ctx => isMouseDown = true;
        controls.Player.MouseClick.canceled += ctx => isMouseDown = false;

        controls.Player.MouseWheelClick.performed += ctx => isMouseMiddleDown = true;
        controls.Player.MouseWheelClick.canceled += ctx => isMouseMiddleDown = false;

    }

    private void OnDisable()
    {
        controls.Disable();

        controls.Player.MouseClick.performed -= ctx => isMouseDown = true;
        controls.Player.MouseClick.canceled -= ctx => isMouseDown = false;

        controls.Player.MouseWheelClick.performed -= ctx => isMouseMiddleDown = true;
        controls.Player.MouseWheelClick.canceled -= ctx => isMouseMiddleDown = false;
    }

}
