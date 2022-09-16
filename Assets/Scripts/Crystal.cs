using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    float health;
    [SerializeField] float maxHealth = 100f;

    public static Crystal Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }

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
            GameManager.Instance.LoseLevel();
        }
    }
}
