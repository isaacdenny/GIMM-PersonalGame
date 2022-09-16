using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    float health;
    [SerializeField] float maxHealth = 100f;

    private void Awake()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0f)
        {
            GameManager.instance.WinLevel();
        }
    }
}
