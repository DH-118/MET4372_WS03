using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : EnemyScript
{
    /*public float HP;
    public int MinusHP;
    public GameObject hitVFXPrefabs;
    public bool playStartAnim;
    public GameObject bullet_1;
    protected float ShootTimer;
    public float ShootCoolDown;*/
    private CameraScript Cam;
    private Wave wave;
    public Image healthBar1;
    public GameObject healthBar2Panel;
    public Image healthBar2;

    /*public void WaveStart()
    {
        if (playStartAnim)
        {
            GetComponent<Animator>().Play("BossInAnim");
        }
    }*/

    private void Start()
    {
        wave = Wave.instance;
        Cam = CameraScript.instance;
    }

    private void Update()
    {
        healthBar1.fillAmount = (HP - 100) / 100f;
        healthBar2.fillAmount = HP / 100f;
        Atk();
        if (HP <= 0)
        {
            Destroy(gameObject);
            Cam.isPause = false;
            wave.UIPanel.SetActive(false);
        }
    }

    void Atk()
    {
        /*if (ShootTimer > 0)
        {
            ShootTimer -= Time.deltaTime;
        }*/
        //if (ShootTimer <= 0)
        {
             GameObject a = ObjectPoolManager.instance.GetObject("EnemyBullet");
             a.transform.position = transform.position;
             a.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

             GameObject b = ObjectPoolManager.instance.GetObject("EnemyBullet");
             b.transform.position = transform.position;
             b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);

             GameObject c = ObjectPoolManager.instance.GetObject("EnemyBullet");
             c.transform.position = transform.position; 
             c.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

             GameObject d = ObjectPoolManager.instance.GetObject("EnemyBullet");
             d.transform.position = transform.position;
             d.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);

             GameObject f = ObjectPoolManager.instance.GetObject("EnemyBullet");
             f.transform.position = transform.position;
             f.GetComponent<Rigidbody2D>().velocity = new Vector2(7.5f, 7.5f);

             GameObject g = ObjectPoolManager.instance.GetObject("EnemyBullet");
             g.transform.position = transform.position;
             g.GetComponent<Rigidbody2D>().velocity = new Vector2(7.5f, -7.5f);

             GameObject h = ObjectPoolManager.instance.GetObject("EnemyBullet");
             h.transform.position = transform.position;
             h.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 7.5f);

             GameObject i = ObjectPoolManager.instance.GetObject("EnemyBullet");
             i.transform.position = transform.position;
             i.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, -7.5f);
        }
        //ShootTimer = ShootCoolDown;
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

        if (collision.gameObject.name == "EnemyRemover")
        {
            Destroy(gameObject);
        }
    }*/
}
