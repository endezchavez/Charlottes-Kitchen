using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour
{
    private CharlotteAI ai;

    private WalkingState walkingstate;

    private void Awake()
    {
        ai = GetComponent<CharlotteAI>();
        walkingstate = GetComponent<WalkingState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ai.isWalking)
        {
            walkingstate.enabled = true;
            this.enabled = false;
        }
    }

    private void OnEnable()
    {
        if(ai.animator == null)
        {
            ai.animator = GetComponent<Animator>();
        }
        ai.animator.SetInteger("animBaseInt", 1);
        //StartCoroutine(SwitchAnimation());
    }

    private void OnDisable()
    {
        ai.animator.SetInteger("animBaseInt", 0);
        StopAllCoroutines();
    }

    IEnumerator SwitchAnimation()
    {
        yield return new WaitForSeconds(5f);
        int i = Random.Range(1, 9);
        ai.animator.SetInteger("animBaseInt", i);
        StartCoroutine(SwitchAnimation());

    }


}
