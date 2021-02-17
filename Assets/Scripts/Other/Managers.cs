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

    [SerializeField]
    private ObjectPool _spaceshipsPool;
    public ObjectPool SpaceshipsPool
    {
        get
        {
            return _spaceshipsPool;
        }
    }

    [SerializeField]
    private ResourcesManager _resourcesManager;
    public ResourcesManager ResourcesManager
    {
        get
        {
            return _resourcesManager;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
