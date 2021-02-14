using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    public static Managers Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    private ObjectPool _projectilesPool;
    public ObjectPool ProjectilesPool
    {
        get
        {
            return _projectilesPool;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
