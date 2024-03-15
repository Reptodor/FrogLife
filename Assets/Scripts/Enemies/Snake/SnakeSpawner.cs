using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _boundaries;
    [SerializeField] private GameObject _snake;
    [SerializeField] private float _spawnLimit;
    [SerializeField] private float _spawnDelay;
    private int _boundariesNumber;
    private float _randomY;
    private float _nextSpawn;
    private Vector2 _whereToSpawn;
    
    public static int Spawned;


    private void Update()
    {
        CaterpillarSpawn();
    }

    private void CaterpillarSpawn()
    {
        if (Time.time > _nextSpawn && Spawned < _spawnLimit)
        {
            _nextSpawn +=  _spawnDelay;

            _whereToSpawn = new Vector2(_boundaries[_boundariesNumber].transform.position.x, _snake.transform.position.y);

            GameObject enemy = Instantiate(_snake, _whereToSpawn, Quaternion.identity);

            if (_boundariesNumber == 0)
            {
                _boundariesNumber = 1;
            }
            else if (_boundariesNumber == 1)
            {
                _boundariesNumber = 0;
            }
            Spawned++;
        }
    }
}
