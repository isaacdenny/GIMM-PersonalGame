using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : StateMachine
{
    [SerializeField] State Idle, Aggro, Attack;
    [SerializeField] LayerMask mask;

    public static LayerMask playerMask;
    public static float attackRange = 7f;

    public static Transform target;

    private void Awake()
    {
        playerMask = mask;
    }
    void Start()
    {
        state = Idle;
    }

    // Update is called once per frame
    void Update()
    {
        base.StateUpdate();
    }

    public override void SetNextState()
    {
        if (state == Idle)
        {
            Set(Aggro);
        }
        else if (state == Aggro)
        {
            Set(Attack);
        }
        else if (state == Attack)
        {
            Set(Idle);
        }
    }

}
