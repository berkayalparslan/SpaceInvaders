using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private int _poolSize;
    private List<GameObject> _poolObjects;
    

    public GameObject GetPoolObject()
    {
        if (_poolObjects.Count > 0)
        {
            for (int i = 0; i < _poolObjects.Count; i++)
            {
                GameObject poolObj = _poolObjects[i];

                if (!poolObj.activeInHierarchy)
                {
                    return poolObj;
                }
            }
        }
        GameObject obj = InstantiatePoolObject();
        _poolObjects.Add(obj);
        return obj;
    }

    private void Awake()
    {
        InitPool();
    }

    private void InitPool()
    {
        _poolObjects = new List<GameObject>(_poolSize);

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = InstantiatePoolObject();
            _poolObjects.Add(obj);
        }
    }

    private GameObject InstantiatePoolObject()
    {
        GameObject obj = GameObject.Instantiate(_prefab);
        obj.SetActive(false);
        return obj;
    }
}
