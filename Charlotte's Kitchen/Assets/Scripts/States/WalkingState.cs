using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private CharlotteAI ai;

    private IdleState idleState;

    private void Awake()
    {
        ai = GetComponent<CharlotteAI>();
        idleState = GetComponent<IdleState>();
    }

    private void Update()
    {
        if (!ai.isWalking)
        {
            idleState.enabled = true;
            this.enabled = false;
        }
    }

    private void OnEnable()
    {
        ai.animator.SetInteger("animOtherInt", 1);
        source.Play();
    }

    private void OnDisable()
    {
        ai.animator.SetInteger("animOtherInt", 0);
        source.Pause();
    }
}
