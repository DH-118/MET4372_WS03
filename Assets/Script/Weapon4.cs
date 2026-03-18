using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4 : Weapon
{
    public override void Shoot()
    {
        if (ShootTimer <= 0)
        {
            GameObject b = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            ShootTimer = ShootCoolDown;
        }
    }
}
