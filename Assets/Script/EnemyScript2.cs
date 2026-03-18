using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript2 : MonoBehaviour
{
    public float HP;
    public float speed;
    public int atk;
    private GameObject player;
    public GameObject hitVFX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
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

        if (collision.gameObject.tag == "PlayerBullet")
        {
            PlayerBullet p = collision.gameObject.GetComponent<PlayerBullet>();
            HP -= p.atk;
            Destroy(collision.gameObject);
            Instantiate(p.HitVFX, collision.gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "PlayerBullet2")
        {
            PlayerBullet2 q = collision.gameObject.GetComponent<PlayerBullet2>();
            HP -= q.atk;
            Destroy(collision.gameObject);
            Instantiate(q.BurnVFX, collision.gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "Burn")
        {
            BurnVFX BF = collision.gameObject.GetComponent<BurnVFX>();
            //Debug.Log("stk");
            HP -= BF.atk;
        }

        if (collision.gameObject.tag == "PlayerBullet4")
        {
            PlayerBullet4 s = collision.gameObject.GetComponent<PlayerBullet4>();
            HP -= s.atk;
        }

        if (collision.gameObject.name == "BulletRemover")
        {
            Destroy(gameObject);
        }

    }
}
