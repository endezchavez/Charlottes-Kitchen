using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StinkyAI : MonoBehaviour
{
    public Transform[] targetPositions;
    public Transform feetPos;

    public float walkRadius = 2f;
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;

    Vector3 randomDir;

    private bool aiIsActive;

    private Rigidbody rb;
    private Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        aiIsActive = true;
        StartCoroutine(DestinationChanger());
    }


    private void FixedUpdate()
    {
        Vector3 dir = (destination - transform.position).normalized;

        if(Vector3.Distance(transform.position, destination) > 0.1f)
        {
            animator.SetBool("isWalking", true);
            transform.LookAt(destination);
            rb.MovePosition(transform.position + dir * Time.deltaTime * 1f);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }


    IEnumerator DestinationChanger()
    {
        while (aiIsActive)
        {
            int randomIndex = Random.Range(0, targetPositions.Length);
            //navMeshAgent.SetDestination(targetPositions[randomIndex].position);
            destination = targetPositions[randomIndex].position;
            yield return new WaitForSeconds(10f);
        }
    }
}
