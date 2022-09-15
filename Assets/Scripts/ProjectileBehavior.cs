using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    internal float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBrain enemy = collision.GetComponent<EnemyBrain>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
