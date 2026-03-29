using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    PlayerController PC;
    public float HP;
    public int MinusHP;
    public GameObject hitVFXPrefabs;
    public bool playStartAnim;
    public GameObject bullet_1;
    protected float ShootTimer;
    public float ShootCoolDown;

    private void Start()
    {
        PC = PlayerController.instance;
    }
    public void WaveStart()
    {
        /*if (playStartAnim)
        {
            GetComponent<Animator>().Play("BossInAnim");
        }*/
    }

    private void Update()
    {
        if (ShootTimer > 0)
        {
            ShootTimer -= Time.deltaTime;
        }
        if (ShootTimer <= 0)
        {
            GameObject b = Instantiate(bullet_1, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
        ShootTimer = ShootCoolDown;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            PlayerBullet p = collision.gameObject.GetComponent<PlayerBullet>();
            HP -= p.atk;
            GameObject i = ObjectPoolManager.instance.GetObject("SelfDestroy");
            i.transform.position = transform.position;
            ObjectPoolManager.instance.PutObject("PlayerBullet", collision.gameObject);
            /*Destroy(collision.gameObject);
            Instantiate(p.HitVFX, collision.gameObject.transform.position, Quaternion.identity);*/
        }
        if (collision.gameObject.CompareTag("PlayerBullet2"))
        {
            PlayerBullet2 q = collision.gameObject.GetComponent<PlayerBullet2>();
            HP -= q.atk;
            GameObject i = ObjectPoolManager.instance.GetObject("BurnVFX");
            i.transform.position = transform.position;
            ObjectPoolManager.instance.PutObject("PlayerBullet2", collision.gameObject);
            /*Destroy(collision.gameObject);
            Instantiate(q.BurnVFX, collision.gameObject.transform.position, Quaternion.identity);*/
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
        if (collision.gameObject.CompareTag("Player") )
        {
            //PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
            PC.HP -= MinusHP;
        }
        if (collision.gameObject.CompareTag("EnemyRemover"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
