using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolableGameObject _prefab;
    [SerializeField] private Vector2 _minPositionCoordinate;
    [SerializeField] private Vector2 _maxPositionCoordinate;
    [SerializeField] private int _objectsInPoolCount;
    [SerializeField] private float _timeBetweenSpawn;

    private List<PoolableGameObject> _poolableGameObjectInPool;
    private SpawnpointGenerator _spawnpointGenerator;
    private Factory _factory;

    private float _counter;

    private int _spawnedCount = 0;

    private void OnValidate()
    {
        if(_prefab == null)
            throw new ArgumentNullException(nameof(_prefab));
        
        if (_objectsInPoolCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(_objectsInPoolCount));

        if (_timeBetweenSpawn <= 0)
            throw new ArgumentOutOfRangeException(nameof(_timeBetweenSpawn));
    }

    public void Initialize()
    {
        _factory = new Factory();

        _poolableGameObjectInPool = new List<PoolableGameObject>(_factory.Create(_prefab, _objectsInPoolCount));

        _spawnpointGenerator = new SpawnpointGenerator(_minPositionCoordinate, _maxPositionCoordinate);

        PoolObjects();
    }

    private void OnEnable()
    {
        if(_poolableGameObjectInPool != null)
            Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Update()
    {
        _counter += Time.deltaTime;
        if (_counter > _timeBetweenSpawn)
        {
            Spawn();
            _counter = 0;
        }
    }

    private void PoolObjects()
    {
        foreach(var poolableGameObjectInPool in _poolableGameObjectInPool)
        {
            poolableGameObjectInPool.gameObject.SetActive(false);
        }

        Subscribe();
    }

    private void Subscribe()
    {
        _poolableGameObjectInPool.ForEach(poolableGameObject => poolableGameObject.Disabled.AddListener(OnObjectDisabled));
    }

    private void Unsubscribe()
    {
        _poolableGameObjectInPool.ForEach(poolableGameObject => poolableGameObject.Disabled.RemoveListener(OnObjectDisabled));
    }

    private void OnObjectDisabled(PoolableGameObject poolableGameObject)
    {
        _poolableGameObjectInPool.Add(poolableGameObject);
        _spawnedCount--;
        _counter = _timeBetweenSpawn;
    }

    private void Spawn()
    {
        if (_spawnedCount < _objectsInPoolCount)
        {
            PoolableGameObject poolableGameObject  = _poolableGameObjectInPool.First();
            poolableGameObject.gameObject.SetActive(true);
            poolableGameObject.transform.position = _spawnpointGenerator.GetRandomSpawnpoint();
            _poolableGameObjectInPool.Remove(poolableGameObject);

            _spawnedCount++;
        }
    }
}
