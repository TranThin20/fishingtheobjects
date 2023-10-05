using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject prefab;
    private List<GameObject> pool;

    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        pool = new List<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = CreateNewObject();
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = Object.Instantiate(prefab);
        return obj;
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // If no inactive object is found, create a new one
        GameObject newObj = CreateNewObject();
        pool.Add(newObj);
        newObj.SetActive(true);
        return newObj;
    }
}
