using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private float _moveHorizontal;
    public static FrogMovement FrogMovementInstance;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        FrogMovementInstance = this;
    }
    
    private void Update()
    {
        GetAxis();
        Flip();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetAxis()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
    }

    private void Flip()
    {
        if (_moveHorizontal > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }

        if (_moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }
    
    private void Move()
    {
        if (_moveHorizontal != 0)
        {
            PlayerAnimation.PlayerAnimationInstance.IsMoving = true;
        }
        else
        {
            PlayerAnimation.PlayerAnimationInstance.IsMoving = false;
        }
        _rigidbody.velocity = new Vector2(_moveHorizontal * _speed, _rigidbody.velocity.y);
    }
}
