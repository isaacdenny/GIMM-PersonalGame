using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBrain brain = collision.GetComponent<PlayerBrain>();
        if (brain != null)
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}
