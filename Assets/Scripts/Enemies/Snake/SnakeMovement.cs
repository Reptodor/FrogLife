using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        _rigidbody.velocity = new Vector2(0, 0);
        _rigidbody.AddForce(transform.right * _speed, ForceMode2D.Force);
        _speed -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            SnakeSpawner.Spawned--;
            Destroy(gameObject);
        }
    }
}
