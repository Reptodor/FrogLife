using UnityEngine;
using UnityEngine.Events;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private float _timeToSound;
    [SerializeField] private float _timer;
    [SerializeField] private UnityEvent _playerSound;
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToSound)
        {
            _playerSound.Invoke();
            _timer = 0;
        }
    }
}
