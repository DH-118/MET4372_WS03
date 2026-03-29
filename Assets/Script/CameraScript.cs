using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float CamMoveSpeed;
    public bool isPause = false;
    public static CameraScript instance;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            transform.position += new Vector3(CamMoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
