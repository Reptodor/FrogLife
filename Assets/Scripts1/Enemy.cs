using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed;
    private float _fishDirection;
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
        if (other.GetComponent<HealthController>() != null)
        {
            other.GetComponent<HealthController>().RecieveDamage(_damage);
        }

        if (other.gameObject.CompareTag("FishWall"))
        {
            EnemySpawner.Spawned--;
            Destroy(gameObject);
        }
    }
}
