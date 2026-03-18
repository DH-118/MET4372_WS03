using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<GameObject> enemy;
    public bool PauseCam;
    public GameObject UIPanel;
    public static Wave instance;

    private void Awake()
    {
        instance = this;
    }
    /*public void Update()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            if (enemy[i] == null)
            {
                enemy.RemoveAt(i);
            }
        }

        if (enemy.Count == 0)
        {
            if (PauseCam)
            {
                CameraScript.instance.isPause = false;
            }
            Destroy(gameObject);
        }
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WaveActivator")
        {
            ActivateWave();
        }
    }

    void ActivateWave()
    {
        if (PauseCam)
        {
            CameraScript.instance.isPause = true;
            UIPanel.SetActive(true);
        }

        for (int i = 0; i < enemy.Count; i++)
        {
            enemy[i].SetActive(true);
            enemy[i].GetComponent<EnemyScript>().WaveStart();
        }
    }
}
