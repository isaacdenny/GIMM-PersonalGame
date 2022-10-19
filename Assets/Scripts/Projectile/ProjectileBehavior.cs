using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private GameObject impactEffectPrefab;
    [SerializeField] private AudioSource impactAudioSource;
    internal float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(impactEffectPrefab, transform.position, Quaternion.identity);

        EnemyBrain enemy = collision.GetComponent<EnemyBrain>();
        Crystal crystal = collision.GetComponent<Crystal>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else if (crystal != null)
        {
            crystal.TakeDamage(damage);
        }

        impactAudioSource.transform.SetParent(null);
        impactAudioSource.Play();
        Destroy(impactAudioSource, 3);

        Destroy(gameObject);
    }
}
