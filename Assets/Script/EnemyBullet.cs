using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, IReusabelObject
{
    PlayerController PC;
    public int atk;
    public GameObject hitVFX;

    private void Start()
    {
        PC = PlayerController.instance;
    }
    public string GetKey()
    {
        return "EnemyBullet";
    }
    public void ResetGameObject()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
            if (collision.gameObject.CompareTag("Player") && !PC.isDefending)
            {
                PC.HP -= atk;
                GameObject v = ObjectPoolManager.instance.GetObject("SelfDestroy");
                v.transform.position = transform.position;
                //DestroyS();
            }
            else if (collision.gameObject.CompareTag("Player") && PC.isDefending)
            {
                //DestroyS();
            }
            DestroyS();
        }
        else if (collision.gameObject.CompareTag("BulletRemover"))
        {
            DestroyS();
        }
    }

    void DestroyS()
    {
        
        ObjectPoolManager.instance.PutObject("EnemyBullet", gameObject);
        //gameObject.SetActive(false);
    }
}
