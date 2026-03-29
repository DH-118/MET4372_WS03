using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript3 : EnemyScript
{
    /*public float HP;
    public int MinusHP;
    public GameObject hitVFXPrefabs;
    public bool playStartAnim;
    public GameObject bullet_1;
    protected float ShootTimer;
    public float ShootCoolDown;

    public void WaveStart()
    {
        if (playStartAnim)
        {
            GetComponent<Animator>().Play("BossInAnim");
        }
    }*/

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
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
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
            PC.HP -= MinusHP;
        }
        if (collision.gameObject.CompareTag("EnemyRemover"))
        {
            Destroy(gameObject);
        }
    }*/
}
