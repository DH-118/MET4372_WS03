using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPath : MonoBehaviour
{
    public float speed;
    public int atk;
    private GameObject player;
    public GameObject hitVFX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.tag == "Player" && !PC.isDefending)
        {
            PC.HP -= atk;
            Instantiate(hitVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && PC.isDefending)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "BulletRemover")
        {
            Destroy(gameObject);
        }

    }
}
