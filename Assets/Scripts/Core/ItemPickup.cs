using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collectible collectible = collision.GetComponent<Collectible>();
        if (collectible == null) return;

        GameManager.Instance.AddToScore(collectible.pointValue);
        Destroy(collectible.gameObject);
    }
}
