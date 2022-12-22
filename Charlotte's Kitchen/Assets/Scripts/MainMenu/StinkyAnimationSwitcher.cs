using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StinkyAnimationSwitcher : MonoBehaviour
{
    Animator animator;

    bool isAnimationSwitching = true;

    private int rand;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(AnimationSwitchTimer());
    }



    IEnumerator AnimationSwitchTimer()
    {
        while (isAnimationSwitching)
        {
            yield return new WaitForSeconds(4f);
            rand = Random.Range(0, 100);
            if(rand > 50)
            {
                SwitchAnimation();
            }
        }
    }

    void SwitchAnimation()
    {
        animator.SetBool("isStamping", true);
        StartCoroutine(StampTimer());
    }

    IEnumerator StampTimer()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("isStamping", false);

    }
}
