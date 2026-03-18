using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PlayerBullet2")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PlayerBullet3")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PlayerBullet4")
        {
            Destroy(collision.gameObject);
        }
    }
}
