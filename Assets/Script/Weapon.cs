using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected float ShootTimer;
    public float ShootCoolDown;
    public GameObject bulletPrefabs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ShootTimer > 0)
        {
            ShootTimer -= Time.deltaTime;
        }
    }

    public virtual void Shoot()
    {

    }
}
