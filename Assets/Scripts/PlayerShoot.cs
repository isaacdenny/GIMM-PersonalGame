using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void Shoot()
    {
        Debug.Log("Shoot");
    }
}
