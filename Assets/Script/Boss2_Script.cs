using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2_Script : MonoBehaviour
{
    public float HP;
    public int MinusHP;
    public GameObject hitVFXPrefabs;
    public GameObject boss2;
    public GameObject FAtk;
    public GameObject EM;
    public GameObject bullet_1;
    public Image healthBar1;
    public GameObject healthBar2Panel;
    public Image healthBar2;
    //public GameObject UIPanel;


    private void Start()
    {
        //UIPanel.SetActive(true);
    }
    void Update()
    {//float hp = GetComponent<EnemyScript>().HP;
        healthBar1.fillAmount = (HP-100) / 100f;
        healthBar2.fillAmount = HP/ 100f;
        
        if (HP <= 0)
            {
                Instantiate(boss2, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
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
        //float hp = GetComponent<EnemyScript>().HP;
       /* if (HP  <= 0)
            {
                //bool PauseCam = GetComponent<CameraScript>().isPause;
                FAtk.SetActive(true);
                Instantiate(boss2, transform.position, Quaternion.identity);
                //PauseCam.isPause = true;
                Destroy(gameObject);
            }*/
        //}

    }
    public void RandomAction()
    {
        int randNum = Random.Range(0, 100);

        if (randNum >= 0 && randNum <= 9)
        {
            GetComponent<Animator>().Play("Boss2_ATK1");
        }
        else if (randNum >= 10 && randNum <= 79)
        {
            GetComponent<Animator>().Play("Boss2_ATK2");
        }
        else
        {
            GetComponent<Animator>().Play("Boss2_idle");
        }

    }

    public void Atk_1()
    {
        Vector2 SpawnPos = this.transform.position;
        SpawnPos.x = Random.Range(2, 8);
        SpawnPos.y = Random.Range(-4, 4);

        Instantiate(EM, SpawnPos, Quaternion.identity);
        
    }

    public void Atk_2()
    {
        GameObject b = Instantiate(bullet_1, transform.position, Quaternion.identity);
        
        int randNum = Random.Range(0, 100);

        if (randNum >= 0 && randNum <= 49)
        {
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 2);
        }
        else if (randNum >= 50 && randNum <= 79)
        {
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
        else
        {
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -2);
        }
    }
}
