using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _playerSound;
    [SerializeField] private float _timeToSound;
    private float _timer;
    private bool _isMoving;

    private void Update()
    {
        CheckForMoving();
        _timer += Time.deltaTime;

        if (_timer >= _timeToSound && !_isMoving)
        {
            _playerSound.Play();
            _timer = 0;
        }
    }

    private void CheckForMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            _isMoving = true;
        else
            _isMoving = false;
    }

}
