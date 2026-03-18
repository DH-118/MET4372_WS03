using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int atk;
    public GameObject hitVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
            if (collision.gameObject.tag == "Player" && !PC.isDefending)
            {
                PC.HP -= atk;
                Instantiate(hitVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Player" && PC.isDefending)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.name == "BulletRemover")
        {
            Destroy(gameObject);
        }
    }
}
