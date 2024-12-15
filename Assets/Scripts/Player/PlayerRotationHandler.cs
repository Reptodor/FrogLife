using UnityEngine;

public class PlayerRotationHandler
{
    private const float _rotationSpeed = 750;
    private Quaternion Rotation;

    public Quaternion GetNewRotation(Vector2 moveDirection)
    {
        float targetAngle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
        float angle = Mathf.MoveTowardsAngle(Rotation.eulerAngles.z, targetAngle, _rotationSpeed * Time.deltaTime);
        Rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        return Rotation; 
    }
}
