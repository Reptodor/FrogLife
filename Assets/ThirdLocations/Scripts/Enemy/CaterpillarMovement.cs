using System;
using UnityEngine;

public class CaterpillarMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _caterpillarDirection;
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
        _rigidbody.AddForce(transform.right * _speed, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
