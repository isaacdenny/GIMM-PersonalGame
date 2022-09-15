using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] float maxHealth = 20;
    PlayerBrain brain;
    float health;

    private void Awake()
    {
        brain = GetComponent<PlayerBrain>();
        health = maxHealth;
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
            brain.Set(brain.playerDead);
        }
    }
}
