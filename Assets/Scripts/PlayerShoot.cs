using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("Properties")]
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float damage = 10f;
    private float timeToNextShoot = 0f;

    // Update is called once per frame
    void Update()
    {
        Shoot(PlayerInputHandler.CheckForShootInput());
        RotateToMouse();
    }

    internal void Shoot(bool shoot)
    {
        if (shoot && Time.time >= timeToNextShoot)
        {
            timeToNextShoot = Time.time + 1 / fireRate;

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(projectileSpeed * firePoint.right, ForceMode2D.Impulse);
            projectile.GetComponent<ProjectileBehavior>().damage = damage;
            Destroy(projectile, 1f);
        }
    }

    internal void RotateToMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - PlayerBrain.rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        PlayerBrain.rb.rotation = angle;
    }
}
