using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _fishes;
    [SerializeField] private float _spawnLimit;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _upperSideY;
    [SerializeField] private float _downSideY;
    private int _fishNumber;
    private float _randomY;
    private float _nextSpawn;
    private Vector2 _whereToSpawn;
    public int FishDirection; 
    
    
    public static int Spawned;

    private void Awake()
    {
        Spawned = 0;
    }
    
    private void Update()
    {
        EnemySpawn();        
    }
    
    private void EnemySpawn()
    {
        if (Time.time > _nextSpawn && Spawned < _spawnLimit)
        {
            _nextSpawn +=  _spawnDelay;
            _randomY = Random.Range(_downSideY, _upperSideY);

            _whereToSpawn = new Vector2(transform.position.x, _randomY);

            GameObject enemy = Instantiate(_fishes[_fishNumber], _whereToSpawn, Quaternion.identity);

            if (_fishNumber == 0)
            {
                _fishNumber = 1;
            }
            else if (_fishNumber == 1)
            {
                _fishNumber = 0;
            }
            Spawned++;
        }
    }
}
