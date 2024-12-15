using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _movementSpeed;

    private IInput _playerInputHandler;
    private MovementHandler _movementHandler;
    private PlayerRotationHandler _playerRotationHandler;
    private Experience _experience;


    public void Initialize(IInput playerInputHandler, float maxExperienceValue)
    {
        _playerInputHandler = playerInputHandler;
        _playerRotationHandler = new PlayerRotationHandler();
        _movementHandler = new MovementHandler(_rigidbody2D, _movementSpeed);
        ExperienceView experienceView = GetComponentInChildren<ExperienceView>();
        _experience = new Experience(experienceView, maxExperienceValue);
    }

    private void OnValidate()
    {
        if(_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Seaweed>() != null)
        {
            _experience.AddExperience(other.GetComponent<Seaweed>().Size);
            other.gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        _movementHandler.HandleMovement(_playerInputHandler.MovementDirenction);
    }
    
    private void Rotate()
    {
        if (_playerInputHandler.MovementDirenction != Vector2.zero)
        {
            transform.rotation = _playerRotationHandler.GetNewRotation(_playerInputHandler.MovementDirenction);
        }
    }

}
