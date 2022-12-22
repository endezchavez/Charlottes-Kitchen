using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TimedTask : Interactable
{
    [SerializeField] InstructionSettings instructionSettings;

    Timer timer;

    List<E_ItemType> currentRequiredItemTypes;

    int currentInstructionIndex = 0;


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        timer = GetComponent<Timer>();

        currentRequiredItemTypes = GetCurrentInstruction().requiredItemTypes;
    }

    public override void PerformInteraction(E_ItemType itemTypeInHand)
    {
        if(currentRequiredItemTypes.Contains(itemTypeInHand))
        {
            timer.SetTimerLength(GetCurrentInstruction().instructionTime);
            timer.StartTimer();

            if (GetCurrentInstruction().consumesItem)
            {
                EventManager.Instance.ItemConsumed(itemTypeInHand);
                ai.DestroyItemsInHand();
            }

            if(GetCurrentInstruction().itemToShow != E_ItemType.NONE)
            {
                Debug.Log("Show Item");
                EventManager.Instance.ItemShowen(GetCurrentInstruction().itemToShow);
            }

            MoveToNextInstruction();

            currentRequiredItemTypes = GetCurrentInstruction().requiredItemTypes;

            
        }
    }

    Instruction GetCurrentInstruction()
    {
        return instructionSettings.instructions[currentInstructionIndex];
    }

    void MoveToNextInstruction()
    {
        currentInstructionIndex++;

        if (currentInstructionIndex >= instructionSettings.instructions.Count)
            currentInstructionIndex = 0;
    }


}
