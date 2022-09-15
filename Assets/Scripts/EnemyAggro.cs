using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : State
{
    [SerializeField] float deAggroRange = 10f;
    


    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
    }

    // Update is called once per frame
    public override void Do()
    {
        CheckIfCanAttack();
    }

    private void CheckIfCanAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, EnemyBrain.attackRange, EnemyBrain.playerMask);
        if (hit != null)
        {
            complete = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, deAggroRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, EnemyBrain.attackRange);
    }
}
