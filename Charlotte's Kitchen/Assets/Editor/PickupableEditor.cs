using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Pickupable))]
[CanEditMultipleObjects]
public class PickupableEditor : Editor
{
    Pickupable pickupable;

    void OnEnable()
    {
        pickupable = (Pickupable)target;

    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        pickupable.pickupHand = (Hand)EditorGUILayout.EnumFlagsField("Pickup Hand", pickupable.pickupHand);
        if (pickupable.pickupHand.HasFlag(Hand.LEFT))
        {
            pickupable.originalLeftHandModel = EditorGUILayout.ObjectField("Original Left Hand Model", pickupable.originalLeftHandModel, typeof(Transform), true) as Transform;
            pickupable.leftHandPrefab = EditorGUILayout.ObjectField("Left Hand Prefab", pickupable.leftHandPrefab, typeof(GameObject), true) as GameObject;
            pickupable.leftHandHeldPosition = EditorGUILayout.Vector3Field("Left Hand Held Position", pickupable.leftHandHeldPosition);
            pickupable.leftHandHeldRotation = EditorGUILayout.Vector3Field("Left Hand Held Rotation", pickupable.leftHandHeldRotation);

        }

        EditorGUILayout.Space();

        if (pickupable.pickupHand.HasFlag(Hand.RIGHT))
        {
            pickupable.originalRightHandModel = EditorGUILayout.ObjectField("Original Right Hand Model", pickupable.originalRightHandModel, typeof(Transform), true) as Transform;
            pickupable.rightHandPrefab = EditorGUILayout.ObjectField("Right Hand Prefab", pickupable.rightHandPrefab, typeof(GameObject), true) as GameObject;
            pickupable.rightHandHeldPosition = EditorGUILayout.Vector3Field("Right Hand Held Position", pickupable.rightHandHeldPosition);
            pickupable.rightHandHeldRotation = EditorGUILayout.Vector3Field("Right Hand Held Rotation", pickupable.rightHandHeldRotation);


        }

        serializedObject.ApplyModifiedProperties();


    }
}
