using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : Weapon
{
    public override void Shoot()
    {
        if (ShootTimer <= 0)
        {
            GameObject b = ObjectPoolManager.instance.GetObject("PlayerBullet");
            b.transform.position = transform.position;
            //GameObject b = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

            b = ObjectPoolManager.instance.GetObject("PlayerBullet");
            b.transform.position = transform.position;
            //b = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);

            b = ObjectPoolManager.instance.GetObject("PlayerBullet");
            b.transform.position = transform.position;
            //b = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(10, -5);
            ShootTimer = ShootCoolDown;
        }
    }
}
