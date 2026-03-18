using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_1_Script : MonoBehaviour
{
    public float HP;
    public int MinusHP;
    public static Boss3_1_Script instance;
    private Boss3_2_Script b2;
    private CameraScript Cam;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cam = CameraScript.instance;
        b2 = Boss3_2_Script.instance;
    }

        private void Update()
    {
        if (b2.HP<=0&&HP <= 0)
        {
            Destroy(gameObject);
            Cam.isPause = false;
        }
    }

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
    }

    public void RandomAction()
    {
        int randNum = Random.Range(0, 100);

        if (randNum >= 0 && randNum <= 49)
        {
            GetComponent<Animator>().Play("boss3_1_Atk1");
        }
        else if (randNum >= 50 && randNum <= 79)
        {
            GetComponent<Animator>().Play("boss3_1_Atk2");
        }
        else
        {
            GetComponent<Animator>().Play("boss3_1_idle");
        }

    }


}
