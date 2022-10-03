using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShoot : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject muzzleFlashPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Properties")]
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float rotationOffset = -15f;
    private float timeToNextShoot = 0f;

    // Update is called once per frame
    void Update()
    {
        Shoot(PlayerInputHandler.CheckForShootInput());
        PlayerBrain.rb.rotation = Helpers.RotateToMouse();
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

            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, firePoint.position, transform.rotation);
            muzzleFlash.transform.Rotate(0, 0, rotationOffset);
            Destroy(muzzleFlash, 0.5f);
        }
    }

    
}
