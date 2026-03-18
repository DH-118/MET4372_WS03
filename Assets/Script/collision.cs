using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public int atk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "remove")
        {
            Destroy(gameObject);
        }
    }
}
