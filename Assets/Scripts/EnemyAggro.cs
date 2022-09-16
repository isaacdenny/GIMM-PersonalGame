using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : State
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float attackRange = 7f;

    [SerializeField] Crystal crystal;

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        crystal = Crystal.Instance;
    }

    // Update is called once per frame
    public override void Do()
    {
        MoveToCrystal();
        CheckIfCanAttack();
    }

    private void MoveToCrystal()
    {
        EnemyBrain.rb.MovePosition(Vector2.MoveTowards(EnemyBrain.rb.position, crystal.transform.position, moveSpeed * Time.deltaTime));
    }

    private void CheckIfCanAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, EnemyBrain.crystalMask);
        if (hit != null)
        {
            complete = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
