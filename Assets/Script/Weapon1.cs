using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : Weapon
{
    public override void Shoot()
    {
        if (ShootTimer <= 0)
        {
            GameObject b = Instantiate(bulletPrefabs, new Vector3(transform.position.x-2, transform.position.y, 0), Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            ShootTimer = ShootCoolDown;
        }
    }
}
