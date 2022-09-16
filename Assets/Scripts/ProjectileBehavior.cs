using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    internal float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBrain enemy = collision.GetComponent<EnemyBrain>();
        Crystal finish = collision.GetComponent<Crystal>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else if (finish != null)
        {
            finish.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
