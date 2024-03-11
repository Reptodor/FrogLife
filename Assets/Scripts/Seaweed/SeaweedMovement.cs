using UnityEngine;

public class SeaweedMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravityForce;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var position = transform.position;
        transform.position = new Vector3(position.x + _speed * Time.deltaTime, position.y - _gravityForce * Time.deltaTime, position.z);
    }
}
