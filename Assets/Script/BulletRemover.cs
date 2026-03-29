using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerBullet2"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerBullet3"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerBullet4"))
        {
            Destroy(collision.gameObject);
        }
    }
}
