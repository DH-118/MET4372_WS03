using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour,IReusabelObject
{
    public int atk;
    public GameObject HitVFX;
    public string GetKey()
    {
        return "PlayerBullet";
    }
    public void ResetGameObject()
    {

    }
}
