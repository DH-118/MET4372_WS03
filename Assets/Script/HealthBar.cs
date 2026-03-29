using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float HealthAmount;
    public GameObject HealthCarrier;
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = HealthAmount/100f;
    }

    public void MinusHealth()
    {
        
    }
}
