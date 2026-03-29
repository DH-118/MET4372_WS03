using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    PlayerController pc;
    public GameObject weaponPrefabs;
    public SpriteRenderer weaponRenderer;
    public float visiblaDist;
    SpriteRenderer sr;
    Collider2D col;

    float dist;
    bool shouldEnable;

    private void Start()
    {
        pc = PlayerController.instance;
        weaponRenderer = GetComponent<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        StartCoroutine(UpdateFloor());

    }

    IEnumerator UpdateFloor()
    {
        while (true)
        {
            dist = Vector2.Distance(transform.position, pc.transform.position);
            shouldEnable = dist < visiblaDist;
            sr.enabled = shouldEnable;
            col.enabled = shouldEnable;
            yield return new WaitForSeconds(dist * 0.01f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject weapon = Instantiate(weaponPrefabs, collision.gameObject.transform);
            //PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            Destroy(pc.weapon.gameObject);
            pc.weapon = weapon.GetComponent<Weapon>();

            //update UI weapon display
            UIController.instance.WeaponIcon.sprite = weaponRenderer.sprite;
            UIController.instance.WeaponIcon.SetNativeSize();

            Destroy(gameObject);
        }
    }
}
