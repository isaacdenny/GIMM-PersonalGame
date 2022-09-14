using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] float maxHealth;
    PlayerBrain brain;
    float health;

    private void Awake()
    {
        brain = GetComponent<PlayerBrain>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        brain.Set(brain.playerStun);
    }

    private void Update()
    {
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        brain.Set(brain.playerDead);

    }
}
