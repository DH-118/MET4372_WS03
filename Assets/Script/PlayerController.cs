using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float FlySpeed;
    Rigidbody2D rb;
    public Weapon weapon;
    public int HP;
    public bool isDefending = false;
    public bool isDefendInCD = false;
    public GameObject DefendVFXPanel;
    public float DefendCoolDown;
    public float DefendTimer;
    public Image healthBar;
    public GameObject ShieldInUseIcon;
    public GameObject ShieldCDIcon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (transform.localPosition.x <= -8)
        {
            move.x = Mathf.Max(0, move.x);
        }
        if (transform.localPosition.x > 8)
        {
            move.x = Mathf.Min(0, move.x);
        }
        if (transform.localPosition.y > 4.4f)
        {
            move.y = Mathf.Min(0, move.y);
        }
        if (transform.localPosition.y < -4.4f)
        {
            move.y = Mathf.Max(0, move.y);
        }
        rb.velocity = move * FlySpeed;

        if (Input.GetKey(KeyCode.F))
        {
            weapon.Shoot();
        }

        if (Input.GetKey(KeyCode.G) && !isDefendInCD)
        {
            isDefending = true;
            DefendVFXPanel.SetActive(true);
            ShieldInUseIcon.SetActive(true);
            Invoke("StopDefending", 0.5f);
        }

        if (DefendTimer > 0)
        {
            DefendTimer -= Time.deltaTime;
        }

        healthBar.fillAmount = HP / 100f;

        if (HP <= 0)
        {
            GameOver();
        }
    }

    void StopDefending()
    {
        isDefending = false;
        DefendVFXPanel.SetActive(false);
        ShieldInUseIcon.SetActive(false );
        isDefendInCD = true;
        ShieldCDIcon.SetActive(true);
        DefendTimer = DefendCoolDown;
        Invoke("DefendEndCD", 0.5f);
    }

    void DefendEndCD()
    {
        isDefendInCD = false;
        ShieldCDIcon.SetActive(false);
    }

    void GameOver()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
