using UnityEngine;
using UnityEngine.Events;

public abstract class PoolableGameObject : MonoBehaviour
{
    [SerializeField] private float _fatalCoordinateY;
    [HideInInspector] public UnityEvent<PoolableGameObject> Disabled;

    public abstract void Initialize();

    public abstract void HandleMovement();

    private void OnDisable()
    {
        Disabled?.Invoke(this);
    }

    public virtual void Update()
    {
        HandleMovement();
        CheckPosition();
    }

    private void CheckPosition()
    {
        if(transform.position.y > _fatalCoordinateY)
            return;
        gameObject.SetActive(false);
    }
    
}
