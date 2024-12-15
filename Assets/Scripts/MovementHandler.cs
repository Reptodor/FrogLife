using System;
using UnityEngine;

public class MovementHandler
{
    private Rigidbody2D _rigidbody2D;
    private float _speed;

    public MovementHandler(Rigidbody2D rigidbody2D, float speed)
    {
        if(rigidbody2D == null)
            throw new ArgumentNullException(nameof(rigidbody2D));

        if(speed <= 0)
            throw new ArgumentOutOfRangeException(nameof(speed));

        _rigidbody2D = rigidbody2D;
        _speed = speed;
    }

    public void HandleMovement(Vector2 movementDirection)
    {
        _rigidbody2D.velocity = movementDirection.normalized * _speed;
    }
}
