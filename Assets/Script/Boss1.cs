using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public float HP;
    public int MinusHP;
    public GameObject hitVFXPrefabs;
    public bool playStartAnim;
    public GameObject bullet_1;
    protected float ShootTimer;
    public float ShootCoolDown;
    private CameraScript Cam;
    private Wave wave;
    public Image healthBar1;
    public GameObject healthBar2Panel;
    public Image healthBar2;

    public void WaveStart()
    {
        if (playStartAnim)
        {
            GetComponent<Animator>().Play("BossInAnim");
        }
    }

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
        /*
        if (ShootTimer > 0)
        {
            ShootTimer -= Time.deltaTime;
        }*/

        //if (ShootTimer <= 0)
        {
            GameObject a = Instantiate(bullet_1, transform.position, Quaternion.identity);
            a.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

            GameObject b = Instantiate(bullet_1, transform.position, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);

            GameObject c = Instantiate(bullet_1, transform.position, Quaternion.identity);
            c.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

            GameObject d = Instantiate(bullet_1, transform.position, Quaternion.identity);
            d.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);

            GameObject f = Instantiate(bullet_1, transform.position, Quaternion.identity);
            f.GetComponent<Rigidbody2D>().velocity = new Vector2(7.5f, 7.5f);

            GameObject g = Instantiate(bullet_1, transform.position, Quaternion.identity);
            g.GetComponent<Rigidbody2D>().velocity = new Vector2(7.5f, -7.5f);

            GameObject h = Instantiate(bullet_1, transform.position, Quaternion.identity);
            h.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 7.5f);

            GameObject i = Instantiate(bullet_1, transform.position, Quaternion.identity);
            i.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, -7.5f);
        }
        //ShootTimer = ShootCoolDown;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
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

        if (collision.gameObject.tag == "Player")
        {
            PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
            PC.HP -= MinusHP;
        }

        if (collision.gameObject.name == "EnemyRemover")
        {
            Destroy(gameObject);
        }
    }
}
