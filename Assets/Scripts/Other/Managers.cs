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

    private ResourcesManager _resourcesManager;
    public ResourcesManager ResourcesManager
    {
        get
        {
            if (_resourcesManager == null)
            {
                _resourcesManager = FindObjectOfType<ResourcesManager>();
            }
            return _resourcesManager;
        }
    }

    private GameManager _gameManager;
    public GameManager GameManager
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }
            return _gameManager;
        }
    }

    private UiManager _uiManager;
    public UiManager UiManager
    {
        get
        {
            if (_uiManager == null)
            {
                _uiManager = FindObjectOfType<UiManager>();
            }
            return _uiManager;
        }
    }

    private PlayerManager _playerManager;
    public PlayerManager PlayerManager
    {
        get
        {
            if (_playerManager == null)
            {
                _playerManager = FindObjectOfType<PlayerManager>();
            }
            return _playerManager;
        }
    }

    private AiSpaceshipsRowsManager _aiSpaceshipsRowManager;
    public AiSpaceshipsRowsManager AiSpaceshipsRowManager
    {
        get
        {
            if (_aiSpaceshipsRowManager == null)
            {
                _aiSpaceshipsRowManager = FindObjectOfType<AiSpaceshipsRowsManager>();
            }
            return _aiSpaceshipsRowManager;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
