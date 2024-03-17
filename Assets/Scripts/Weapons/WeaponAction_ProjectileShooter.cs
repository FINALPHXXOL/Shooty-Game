using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction_ProjectileShooter : WeaponAction
{
    public float damageDone;
    public float fireRate;

    private float lastShotTime;
    public Transform firePoint;
    public GameObject projectilePrefab;

    public void Shoot()
    {
        
        // Check if it is time to fire our weapon 
        float secondsPerShot = 1 / fireRate;
        if (Time.time >= lastShotTime + secondsPerShot)
        {
            // if so...
            print("It should shoot");
            // Instantiate the projectile
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as GameObject;

            // Set the layer for the projectile
            projectile.gameObject.layer = this.gameObject.layer;

            // Set the data for the projectile
            Projectile projectileData = projectile.GetComponent<Projectile>();
            if (projectileData != null)
            {
                projectileData.damage = damageDone;
            }

            // Save the time we shot
            lastShotTime = Time.time;
        }
    }
}
