using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TimedTask : Interactable
{
    [SerializeField] InstructionSettings instructionSettings;

    Timer timer;

    E_ItemType currentRequiredItemType;

    int currentInstructionIndex = 0;

    Hideable hideable;
    Hideable hideableInHand;


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        timer = GetComponent<Timer>();

        currentRequiredItemType = GetCurrentInstruction().requiredItemType;

        hideable = GetComponent<Hideable>();

    }

    private void Update()
    {
        if (timer.isTimerFinished)
        {
            if(GetCurrentInstruction().itemToHideOnCompletion != E_ItemType.NONE)
            {
                hideable.HideItem(GetCurrentInstruction().itemToHideOnCompletion);
            }

            if (GetCurrentInstruction().itemToShowOnCompletion != E_ItemType.NONE)
            {
                hideable.ShowItem(GetCurrentInstruction().itemToShowOnCompletion);
            }

            if (GetCurrentInstruction().itemToResetOnCompletion != E_ItemType.NONE)
            {
                EventManager.Instance.ItemReset(GetCurrentInstruction().itemToResetOnCompletion);
            }

            timer.ResetTimer();
        }
    }

    public override void PerformInteraction(ItemType itemTypeInHand)
    {

        if (itemTypeInHand == null && GetCurrentInstruction().requiredItemType != E_ItemType.NONE)
            return;

        if (itemTypeInHand != null && itemTypeInHand.itemType != GetCurrentInstruction().requiredItemType)
            return;

        if(itemTypeInHand != null)
        {
            hideableInHand = itemTypeInHand.GetComponent<Hideable>();
        }

        if (hideableInHand && !hideableInHand.IsItemEnabled(GetCurrentInstruction().requiredHideableItems))
            return;


        timer.SetTimerLength(GetCurrentInstruction().instructionTime);
        timer.StartTimer();

        
        if (GetCurrentInstruction().itemToGivePlayer != null)
        {
            GivePlayerItem(GetCurrentInstruction().itemToGivePlayer);
        }

        if (GetCurrentInstruction().itemToShowInAppliance != E_ItemType.NONE)
        {
            if (hideable)
            {
                hideable.ShowItem(GetCurrentInstruction().itemToShowInAppliance);
            }
        }

        if (GetCurrentInstruction().consumesItem)
        {
            EventManager.Instance.ItemConsumed(itemTypeInHand.itemType);
            ai.DestroyItemsInHand();
        }

        /*
        if (GetCurrentInstruction().requiredHideableItems != E_ItemType.NONE)
        {
            if (!hideableInHand)
                return;

            Debug.Log(hideableInHand.IsItemEnabled(GetCurrentInstruction().requiredHideableItems));
            if (!hideableInHand.IsItemEnabled(GetCurrentInstruction().requiredHideableItems))
                return;

        }
        */

        if (hideableInHand)
        {
            if (GetCurrentInstruction().itemToShowInHand != E_ItemType.NONE)
            {
                if (hideableInHand)
                {
                    hideableInHand.ShowItem(GetCurrentInstruction().itemToShowInHand);
                }

            }

            if (GetCurrentInstruction().itemToHideInHand != E_ItemType.NONE)
            {
                if (hideableInHand)
                {
                    hideableInHand.HideItem(GetCurrentInstruction().itemToHideInHand);
                }
            }
        }
        
        

        MoveToNextInstruction();

        currentRequiredItemType = GetCurrentInstruction().requiredItemType;

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
