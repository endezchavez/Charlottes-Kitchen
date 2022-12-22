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

    public override void PerformInteraction(ItemType itemTypeInHand)
    {
        Hideable hideableInHand = itemTypeInHand.GetComponent<Hideable>();
        Hideable hideableInAppliance = GetComponent<Hideable>();

        if (!currentRequiredItemTypes.Contains(itemTypeInHand.itemType))
            return;

        if(GetCurrentInstruction().requiredHideableItems != E_ItemType.NONE)
        {
            if (!hideableInHand)
                return;

            if (!hideableInHand.IsItemEnabled(GetCurrentInstruction().requiredHideableItems))
                return;

        }

        timer.SetTimerLength(GetCurrentInstruction().instructionTime);
        timer.StartTimer();

        if (GetCurrentInstruction().consumesItem)
        {
            EventManager.Instance.ItemConsumed(itemTypeInHand.itemType);
            ai.DestroyItemsInHand();
        }

        if(GetCurrentInstruction().itemToShowInHand != E_ItemType.NONE)
        {
            if (hideableInHand)
            {
                hideableInHand.ShowItem(GetCurrentInstruction().itemToShowInHand);
            }
        }

        /*
        if (GetCurrentInstruction().itemToShowInAppliance != E_ItemType.NONE)
        {
            if (hideableInAppliance)
            {
                hideableInAppliance.ShowItem(GetCurrentInstruction().itemToShowInAppliance);
            }
        }
        */

        MoveToNextInstruction();

        currentRequiredItemTypes = GetCurrentInstruction().requiredItemTypes;

            
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
