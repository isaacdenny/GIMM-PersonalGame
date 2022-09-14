using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : State
{
    [SerializeField] float aggroRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfAggroed();
    }

    private void CheckIfAggroed()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, aggroRange, EnemyBrain.playerMask);
        if (hit != null && !complete)
        {
            EnemyBrain.target = hit.transform;
            complete = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
