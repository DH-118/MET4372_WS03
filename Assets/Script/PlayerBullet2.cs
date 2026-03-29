using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2 : MonoBehaviour,IReusabelObject
{
    public int atk;
    public GameObject BurnVFX;
    public string GetKey()
    {
        return "PlayerBullet2";
    }
    public void ResetGameObject()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("hit");
            EnemyScript e = collision.gameObject.GetComponent<EnemyScript>();
            e.HP -= atk;
            //Instantiate(BurnVFX, transform.position, Quaternion.identity);
            
            //Destroy(gameObject);
        }
    }
}
