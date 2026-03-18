using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet4 : MonoBehaviour
{
    public float atk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript e = collision.gameObject.GetComponent<EnemyScript>();
            e.HP -= atk;
        }
    }
}
