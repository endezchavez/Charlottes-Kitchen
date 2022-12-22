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
    public List<E_ItemType> requiredItemTypes;
    public float instructionTime;
    public bool consumesItem;
    public E_ItemType itemToShow;
}
