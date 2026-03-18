using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public GameObject weaponPrefabs;
    public SpriteRenderer weaponRenderer;

    private void Start()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject weapon = Instantiate(weaponPrefabs, collision.gameObject.transform);
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            Destroy(pc.weapon.gameObject);
            pc.weapon = weapon.GetComponent<Weapon>();

            //update UI weapon display
            UIController.instance.WeaponIcon.sprite = weaponRenderer.sprite;
            UIController.instance.WeaponIcon.SetNativeSize();

            Destroy(gameObject);
        }
    }
}
