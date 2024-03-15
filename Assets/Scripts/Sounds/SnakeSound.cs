using UnityEngine;
using UnityEngine.Events;

public class SnakeSound : MonoBehaviour
{
    [SerializeField] private UnityEvent _hissEvent;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _seeDistance;
    private void Update()
    {
        if (_player.transform.position.x - transform.position.x > _seeDistance ||
            _player.transform.position.x - transform.position.x > -_seeDistance)
        {
            _hissEvent.Invoke();
        }    
    }
}
