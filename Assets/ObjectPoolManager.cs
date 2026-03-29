using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IReusabelObject
{
    string GetKey();
    void ResetGameObject();
}

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public List<GameObject> reusableObjs;

    Dictionary<string, List<GameObject>> ObjectPools = new Dictionary<string, List<GameObject>>();
    Dictionary<string, GameObject> reusablePrefabs = new Dictionary<string, GameObject>();

    public int BulCount = 0;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < reusableObjs.Count; i++)
        {
            if (reusableObjs[i].GetComponent<IReusabelObject>() != null)
            {
                reusablePrefabs[reusableObjs[i].GetComponent<IReusabelObject>().GetKey()] = reusableObjs[i];
                ObjectPools[reusableObjs[i].GetComponent<IReusabelObject>().GetKey()] = new List<GameObject>();
            }
            else
            {
                Debug.Log("[ERROR]: " + reusableObjs[i].name + " is not IReusableObject");
            }
        }
    }

    public GameObject GetObject(string key)
    {
        if (!ObjectPools.ContainsKey(key))
        {
            Debug.Log("[ObjectPoolManager] GetObject with key not resigtered: " + key);
            return null;
        }

        List<GameObject> pool = ObjectPools[key];

        if (pool.Count > 0)
        {
            GameObject obj = pool[0];
            pool.RemoveAt(0);
            obj.SetActive(true);
            obj.GetComponent<IReusabelObject>().ResetGameObject();

            return obj;
        }
        else
        {
            if (key == "EnemyBullet") { BulCount++; }
            return Instantiate(reusablePrefabs[key]);
        }
    }

    public void PutObject(string key, GameObject obj)
    {
        if (!ObjectPools.ContainsKey(key))
        {
            Debug.Log("[ObjectPoolManager] PutObject with key not resigtered: " + key);
            return;
        }
        obj.SetActive(false);
        ObjectPools[key].Add(obj);
    }
}
