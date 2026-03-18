using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss2_final : MonoBehaviour
{
    public float hp;
    public int MinusHP;
    public GameObject Atk1;
    public GameObject Atk2;
    public GameObject EM;
    private GameObject player;
    private CameraScript Cam ;
    public Image healthBar1;
    public GameObject healthBar2Panel;
    public Image healthBar2;

    void Start()
    {
        Cam = CameraScript.instance;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        healthBar1.fillAmount = (hp - 100) / 100f;
        healthBar2.fillAmount = hp / 100f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            PlayerBullet p = collision.gameObject.GetComponent<PlayerBullet>();
            hp -= p.atk;
            Destroy(collision.gameObject);
            Instantiate(p.HitVFX, collision.gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "PlayerBullet2")
        {
            PlayerBullet2 q = collision.gameObject.GetComponent<PlayerBullet2>();
            hp -= q.atk;
            Destroy(collision.gameObject);
            Instantiate(q.BurnVFX, collision.gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "Burn")
        {
            BurnVFX BF = collision.gameObject.GetComponent<BurnVFX>();
            //Debug.Log("stk");
            hp -= BF.atk;
        }

        if (collision.gameObject.tag == "PlayerBullet4")
        {
            PlayerBullet4 s = collision.gameObject.GetComponent<PlayerBullet4>();
            hp -= s.atk;
        }

        if (collision.gameObject.tag == "Player")
        {
            PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
            PC.HP -= MinusHP;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
            Cam.isPause = false;
        }

    }
    
    public void RandomAction()
    {
        int randNum = Random.Range(0, 100);

        if (randNum >= 0 && randNum <= 39)
        {
            GetComponent<Animator>().Play("Boss2f_ATK1");
        }
        else if (randNum >= 40 && randNum <= 59)
        {
            GetComponent<Animator>().Play("Boss2f_ATK2");
        }else if(randNum >= 60 && randNum <= 79)
        {
            Vector2 SpawnPos = this.transform.position;
            SpawnPos.x = Random.Range(2, 8);
            SpawnPos.y = Random.Range(-4, 4);

            Instantiate(EM, SpawnPos, Quaternion.identity);
        }
        else
        {
            GetComponent<Animator>().Play("Boss2f_idle");
        }

    }

    public void Atk_1()
    {
        Atk1.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        Instantiate(Atk1, Atk1.transform.position, Quaternion.identity);

    }

    public void Atk_2()
    {
        GameObject b = Instantiate(Atk2, transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
       
    }

    

}
