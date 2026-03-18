using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss3_Script : MonoBehaviour
{
    public float hp;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject bullet1;
    public GameObject bullet2;

    public Transform Boss1_p;
    public Transform Boss2_p;

    public Image healthBar1;
    public GameObject healthBar2Panel;
    public Image healthBar2;
    // Start is called before the first frame update
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

        if (hp <= 0)
             {
                 Instantiate(boss1, Boss1_p.position, Quaternion.identity);
                 Instantiate(boss2, Boss2_p.position, Quaternion.identity);
                 Destroy(gameObject);
             }
        

    }
    public void RandomAction()
    {
        int randNum = Random.Range(0, 100);

        if (randNum >= 0 && randNum <= 49)
        {
            GetComponent<Animator>().Play("Boss3_ATK1");
        }
        else if (randNum >= 50 && randNum <= 79)
        {
            GetComponent<Animator>().Play("Boss3_ATK2");
        }
        else
        {
            GetComponent<Animator>().Play("Boss3_idle");
        }

    }
    public void Atk_1()
    {
        GameObject b = Instantiate(bullet1, transform.position, Quaternion.identity); 
        b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        
    }
    public void Atk_2()
    {
        GameObject b = Instantiate(bullet2, transform.position, Quaternion.identity);

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
