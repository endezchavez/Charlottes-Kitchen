using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingState : MonoBehaviour
{
    public float choppingTime = 5f;

    private CharlotteAI ai;

    private void Awake()
    {
        ai = GetComponent<CharlotteAI>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
