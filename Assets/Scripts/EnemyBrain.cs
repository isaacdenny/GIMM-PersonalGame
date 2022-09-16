using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBrain : StateMachine
{
    [SerializeField] State Aggro, Attack, Stun, Dead;
    [SerializeField] LayerMask mask;

    public static LayerMask crystalMask;
    

    public static Transform target;
    public static Rigidbody2D rb;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] int enemyMinPointValue = 100;
    [SerializeField] int enemyMaxPointValue = 300;

    internal void InitEnemy()
    {
        crystalMask = mask;
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        Set(Aggro);
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
        GameManager.Instance.AddToScore(Random.Range(enemyMinPointValue, enemyMaxPointValue));
        Set(Dead);
    }

    public override void SetNextState()
    {
        if (state == Aggro)
        {
            Set(Attack);
        }
        else if (state == Attack)
        {
            Set(Aggro);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}
