using UnityEngine;

public class SeaweedSpawner : Respawner
{
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _spawnLimit;
    [SerializeField] private float _spawnDelay;
    private int _seaweedIndex;
    private float _nextSpawn;
    private float _timeToSpawn;
    
    public static int Spawned;

    private void Awake()
    {
        Spawned = 0;
        _timeToSpawn = 0;
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
        _timeToSpawn += Time.deltaTime;
        if (_timeToSpawn > _nextSpawn && Spawned < _spawnLimit)
        {
            ChooseSeaweed();
            _nextSpawn +=  _spawnDelay;
            GameObject Item = Instantiate(_items[_seaweedIndex], ChoosePlace(), Quaternion.identity);
            Spawned++;
        }
    }
}
