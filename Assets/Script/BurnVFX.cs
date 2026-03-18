using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnVFX : MonoBehaviour
{
    public bool Burn = false;
    public float BurnTimer;
    public float BurnCoolDown;
    public int atk;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StopBurnning", 3);
    }

    void StopBurnning()
    {
        Destroy(gameObject);
    }
    void Update()
    {

    }
}
