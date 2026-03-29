using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    public static WeaponUI instance;
    public SpriteRenderer sprite;

    private void Awake()
    {
        instance = this;
    }
}
