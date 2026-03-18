using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet3 : MonoBehaviour
{
    public int atk;
    public GameObject PlayerBullet3a;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("c");
            EnemyScript e = collision.gameObject.GetComponent<EnemyScript>();
            e.HP -= atk;
            GameObject a = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            a.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

            GameObject b = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);

            GameObject c = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            c.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

            GameObject d = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            d.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);

            GameObject f = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            f.GetComponent<Rigidbody2D>().velocity = new Vector2(7.5f, 7.5f);

            GameObject g = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            g.GetComponent<Rigidbody2D>().velocity = new Vector2(7.5f, -7.5f);

            GameObject h = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            h.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 7.5f);

            GameObject i = Instantiate(PlayerBullet3a, transform.position, Quaternion.identity);
            i.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, -7.5f);

            Destroy(gameObject);
        }
    }
}
