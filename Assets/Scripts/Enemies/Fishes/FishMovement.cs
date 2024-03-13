using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        ChoosdeDirection();
    }
    
    private void FixedUpdate()
    {
        EnemyMove();
    }
    
    private void EnemyMove()
    {
        _rigidbody.AddForce(transform.right * _speed * transform.localScale.x, ForceMode2D.Force);
    }
    
    private void ChoosdeDirection()
    {
        if (transform.position.x < -1.626884f)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FishWall"))
        {
            FishSpawner.Spawned--;
            Destroy(gameObject);
        }
    }
}
