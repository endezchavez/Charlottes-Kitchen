using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider)), DisallowMultipleComponent]
public class Destination : MonoBehaviour
{
    [SerializeField] Transform standTransform;
    public Interactable[] interactables;

    [HideInInspector] public Vector3 standPos, lookDir;

    private void Awake()
    {
        standPos = standTransform.position;
        lookDir = standTransform.forward;
    }

}
