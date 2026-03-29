using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet4 : MonoBehaviour,IReusabelObject
{
    public float atk;

    public string GetKey()
    {
        return "PlayerBullet4";
    }
    public void ResetGameObject()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript e = collision.gameObject.GetComponent<EnemyScript>();
            e.HP -= atk;
        }
    }
}
