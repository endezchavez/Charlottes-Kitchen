using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InstructionSettings : ScriptableObject
{
    public List<Instruction> instructions;
    
}

[System.Serializable]
public class Instruction
{
    public E_ItemType requiredItemType;
    public E_ItemType requiredHideableItems;
    public float instructionTime;
    public bool consumesItem;
    public E_ItemType itemToShowInHand;
    public E_ItemType itemToHideInHand;
    public E_ItemType itemToShowInAppliance;
    public E_ItemType itemToHideInAppliance;
    public E_ItemType itemToShowOnCompletion;
    public E_ItemType itemToHideOnCompletion;
    public E_ItemType itemToResetOnCompletion;
    public StorableItem itemToGivePlayer;
}
