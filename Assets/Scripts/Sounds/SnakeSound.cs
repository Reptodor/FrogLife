using UnityEngine;
using UnityEngine.Events;

public class SnakeSound : MonoBehaviour
{
    [SerializeField] private UnityEvent _hissEvent;
    [SerializeField] private LayerMask _player;
    [SerializeField] private float _seeDistance;
    [SerializeField] private bool _seePlayer;
    private SnakeSound _snakeSound;

    private void Awake()
    {
        _snakeSound = this;
    }
    
    private void Update()
    {
        SearchingForPlayer();
        if (_seePlayer)
        {
            _hissEvent.Invoke();
            _snakeSound.enabled = false;
        }    
    }

    private void SearchingForPlayer()
    {
        _seePlayer = Physics2D.Raycast(transform.position, Vector2.left, _seeDistance, _player);
    }
}
