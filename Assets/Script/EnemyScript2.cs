using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript2 : EnemyScript
{
    PlayerController PC;
    //public float HP;
    public float speed;
    public int atk;
    private GameObject player;
    public GameObject hitVFX;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        PC = PlayerController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PC.transform.position, speed * Time.deltaTime);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!PC.isDefending)
            {
                PC.HP -= atk;
                GameObject i = ObjectPoolManager.instance.GetObject("SelfDestroy");
                i.transform.position = transform.position;
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            base.OnTriggerEnter2D(collision);
        }
        /*PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && !PC.isDefending)
        {
            PC.HP -= atk;
            Instantiate(hitVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player") && PC.isDefending)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            PlayerBullet p = collision.gameObject.GetComponent<PlayerBullet>();
            HP -= p.atk;
            Destroy(collision.gameObject);
            Instantiate(p.HitVFX, collision.gameObject.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("PlayerBullet2"))
        {
            PlayerBullet2 q = collision.gameObject.GetComponent<PlayerBullet2>();
            HP -= q.atk;
            Destroy(collision.gameObject);
            Instantiate(q.BurnVFX, collision.gameObject.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Burn"))
        {
            BurnVFX BF = collision.gameObject.GetComponent<BurnVFX>();
            //Debug.Log("stk");
            HP -= BF.atk;
        }
        if (collision.gameObject.CompareTag("PlayerBullet4"))
        {
            PlayerBullet4 s = collision.gameObject.GetComponent<PlayerBullet4>();
            HP -= s.atk;
        }
        if (collision.gameObject.CompareTag("BulletRemover"))
        {
            Destroy(gameObject);
        }*/
    }
}
