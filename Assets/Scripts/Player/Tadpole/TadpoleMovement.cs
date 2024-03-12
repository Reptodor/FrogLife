using UnityEngine;

public class TadpoleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _tPosition;
    private bool _isMoving = false;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TriggerPosition();
            TransformRotation();
        }

        if (_isMoving)
        {
            Movement(_speed);
        }
    }

    private void TriggerPosition()
    {
        _tPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _tPosition.z = transform.position.z;

        _isMoving = true;
    }
    private void Movement(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, _tPosition, speed * Time.deltaTime);

        if (transform.position == _tPosition)
        {
            _isMoving = false;
        }
    }

    private void TransformRotation()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y);
        transform.up = direction;
        
    }
}
