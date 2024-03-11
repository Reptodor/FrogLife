using UnityEngine;

public class SeaweedSpawner : Respawner
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private float _spawnLimit;
    [SerializeField] private float _spawnDelay;
    private int _seaweedIndex;
    private float _nextSpawn;
    
    public static int Spawned;

    private void Awake()
    {
        Spawned = 0;
    }
    
    private void Update()
    {
        Spawn();
    }

    private void ChooseSeaweed()
    {
        _seaweedIndex = Random.Range(0, _items.Length);
    }
    
    private void Spawn()
    {
        if (Time.time > _nextSpawn && Spawned < _spawnLimit)
        {
            ChooseSeaweed();
            _nextSpawn +=  _spawnDelay;
            GameObject Item = Instantiate(_items[_seaweedIndex], ChoosePlace(), Quaternion.identity);
            Spawned++;
        }
    }
}
