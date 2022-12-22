using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float movementSpeed;
    [SerializeField] float movementTime;

    [SerializeField] float rotationAmount;
    [SerializeField] Vector3 zoomAmount;

    Vector3 newPos;
    Quaternion newRot;
    Vector3 newZoom;

    Vector3 dragStartPos;
    Vector3 dragCurrentPos;

    Vector3 rotStartPos;
    Vector3 rotCurrentPos;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
        newRot = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
        
    }

    void HandleMouseInput()
    {
        /*
        float scrollY = InputManager.Instance.GetMouseScrollY();
        scrollY = Mathf.Clamp(scrollY, -1, 1);

        if(scrollY != 0)
        {
            newZoom += scrollY * zoomAmount;
        }
        */

        if (InputManager.Instance.PlayerClickedThisFrame())
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = cam.ScreenPointToRay(InputManager.Instance.GetMousePos());

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                dragStartPos = ray.GetPoint(entry);
            }
        }

        if (InputManager.Instance.isMouseDown)
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = cam.ScreenPointToRay(InputManager.Instance.GetMousePos());

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPos = ray.GetPoint(entry);

                newPos = transform.position + dragStartPos - dragCurrentPos;
            }
        }

        if (InputManager.Instance.PlayerClickedMiddleMouseThisFrame())
        {
            rotStartPos = InputManager.Instance.GetMousePos();
        }

        if (InputManager.Instance.isMouseMiddleDown)
        {
            rotCurrentPos = InputManager.Instance.GetMousePos();

            Vector3 difference = rotStartPos - rotCurrentPos;

            rotStartPos = rotCurrentPos;

            newRot *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }

        //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * movementTime);
        //cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
