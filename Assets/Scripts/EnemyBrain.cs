using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBrain : StateMachine
{
    [SerializeField] State Idle, Aggro, Attack, Stun, Dead;
    [SerializeField] LayerMask mask;

    public static LayerMask playerMask;
    public static float attackRange = 7f;

    public static Transform target;
    public static Rigidbody2D rb;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] int enemyMinPointValue = 100;
    [SerializeField] int enemyMaxPointValue = 300;

    private void Awake()
    {
        playerMask = mask;
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        state = Idle;
    }

    // Update is called once per frame
    void Update()
    {
        base.StateUpdate();
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.instance.AddToScore(Random.Range(enemyMinPointValue, enemyMaxPointValue));
        Set(Dead);
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

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}
