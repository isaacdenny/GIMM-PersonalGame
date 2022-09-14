using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    [SerializeField] float projectileSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        Shoot(PlayerInputHandler.CheckForShootInput());
    }

    internal void Shoot(bool shoot)
    {
        if (shoot)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(projectileSpeed * firePoint.right, ForceMode2D.Impulse);
        }
    }
}
