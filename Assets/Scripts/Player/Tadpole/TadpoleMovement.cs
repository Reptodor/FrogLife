using UnityEngine;

public class TadpoleMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    private Vector3 _tPosition;
    private bool _isMoving = false;

    [Header("Wall Check")]
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private float _allowedDistanceToWall;
    [SerializeField] private bool _seeWall;

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
        CheckForWall();

        if (!CheckForWall())
        {
            transform.position = Vector3.MoveTowards(transform.position, _tPosition, speed * Time.deltaTime);
            if (transform.position == _tPosition)
            {
                _isMoving = false;
            }
        }
    }

    private bool CheckForWall()
    {
        _seeWall = Physics2D.Raycast(transform.position, Vector2.up, _allowedDistanceToWall, _wallLayer);

        return _seeWall;
    }

    private void TransformRotation()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(touchPosition.x - transform.position.x, touchPosition.y - transform.position.y);
        transform.up = direction;
    }
}
