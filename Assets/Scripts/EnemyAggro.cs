using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : State
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float attackRange = 7f;
    Rigidbody2D rb;

    [SerializeField] Crystal crystal;

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        crystal = Crystal.Instance;
        rb = EnemyBrain.rb;
    }

    // Update is called once per frame
    public override void Do()
    {
        MoveToCrystal();
        CheckIfCanAttack();
    }

    private void MoveToCrystal()
    {
        //Debug.Log("MovingTo" + crystal.transform.position);
        rb.MovePosition(Vector2.MoveTowards(transform.position, crystal.transform.position, moveSpeed * Time.deltaTime));
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
