using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    
    [SerializeField] private float _upperSideY;
    [SerializeField] private float _downSideY;
    [SerializeField] private float _leftSideX;
    [SerializeField] private float _rightSideX;
    [SerializeField] private float _spawnLimit;
    [SerializeField] private float _spawnDelay;

    private Vector2 _whereToSpawn;
    public static int Spawned;
    private float _nextSpawn;
    private float _randomX;
    private float _randomY;


    private void Awake()
    {
        Spawned = 0;
    }
    
    private void Update()
    {
        Respawn();
    }
    
    private void Respawn()
    {
        if (Time.time > _nextSpawn && Spawned < _spawnLimit)
        {
            _nextSpawn +=  _spawnDelay;
            _randomX = Random.Range(_leftSideX, _rightSideX);
            _randomY = Random.Range(_downSideY, _upperSideY);

            _whereToSpawn = new Vector2(_randomX, _randomY);

            GameObject Item = Instantiate(_item, _whereToSpawn, Quaternion.identity);
            
            Spawned++;

        }
    }
    

}
