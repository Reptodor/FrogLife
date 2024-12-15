using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Seaweed : PoolableGameObject
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float[] _sizes;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _typesCount;

    private MovementHandler _movementHandler;
    private int _currentTypeIndex;

    public float Size => _sizes[_currentTypeIndex];


    private void OnValidate()
    {
        if(_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();

        if(_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();

        if(_sizes.Length != _typesCount)
            _sizes = new float[_typesCount];

        if(_sprites.Length != _typesCount)
            _sprites = new Sprite[_typesCount];
    }

    public override void Initialize()
    {
        _movementHandler = new MovementHandler(_rigidbody2D, _movementSpeed);
    }

    private void OnEnable()
    {
        ChooseRandomType();
    }
    
    public override void HandleMovement()
    {
        Vector2 movementDirection = new Vector2(transform.right.x, _rigidbody2D.velocity.y);
        _movementHandler.HandleMovement(movementDirection);
    }

    private void ChooseRandomType()
    {
        _currentTypeIndex = Random.Range(0, _typesCount);
        _spriteRenderer.sprite = _sprites[_currentTypeIndex];
    }
}
