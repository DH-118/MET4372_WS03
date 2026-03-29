using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnVFX : MonoBehaviour, IReusabelObject
{
    public bool Burn = false;
    public float BurnTimer;
    public float BurnCoolDown;
    public int atk;

    public string GetKey()
    {
        return "BurnVFX";
    }
    public void ResetGameObject()
    {
        Invoke("StopBurnning", 3);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StopBurnning", 3);
    }

    void StopBurnning()
    {
        ObjectPoolManager.instance.PutObject("BurnVFX", gameObject);
    }
}
