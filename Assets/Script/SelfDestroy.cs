using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour, IReusabelObject
{
    public string GetKey()
    {
        return "SelfDestroy";
    }
    public void ResetGameObject()
    {
        
    }
    public void DestroyGameObject()
    {
        //Destroy(gameObject);
        ObjectPoolManager.instance.PutObject("SelfDestroy", gameObject);
    }
}
