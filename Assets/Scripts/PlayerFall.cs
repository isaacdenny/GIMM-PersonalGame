using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : State
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckRadius = .1f;
    [SerializeField] private Transform groundCheck;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Do()
    {
        base.Do();

        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask))
        {
            complete = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
