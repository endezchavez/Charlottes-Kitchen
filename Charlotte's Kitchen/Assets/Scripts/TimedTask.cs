using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TimedTask : Interactable
{
    Timer timer;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        timer = GetComponent<Timer>();


    }

    private void Update()
    {
        
    }

    public override void PerformInteraction(ItemType itemTypeInHand)
    {



    }

}
