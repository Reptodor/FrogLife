using UnityEngine;

public class FishSpawner : Respawner
{
    [SerializeField] private GameObject[] _fishes;
    [SerializeField] private int _spawnLimit;
    [SerializeField] private float _spawnDelay;
    private int _fishIndex;
    private float _nextSpawn;
    private float _timeToSpawn;
    private bool _isRightSpawn;
    
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

    private void ChooseFish()
    {
        if (_fishIndex == 0)
        {
            _fishIndex = 1;
        }
        else if (_fishIndex == 1)
        {
            _fishIndex = 0;
        }
    }
    
    private void Spawn()
    {
        _timeToSpawn += Time.deltaTime;
        if (_timeToSpawn > _nextSpawn && Spawned < _spawnLimit)
        {
            ChooseFish();
            _nextSpawn +=  _spawnDelay;
            if (_isRightSpawn)
            {
                GameObject Item = Instantiate(_fishes[_fishIndex], new Vector2(-7.61f , ChooseVerticalPosition()), Quaternion.identity);
                _isRightSpawn = false;
            }
            else
            {
                GameObject Item = Instantiate(_fishes[_fishIndex], new Vector2(11.03f , ChooseVerticalPosition()), Quaternion.identity);
                _isRightSpawn = true;
            }
            Spawned++;
        }
    }
}
