using UnityEngine;

public abstract class Respawner : MonoBehaviour
{
    [Header("Borders")]
    [SerializeField] private GameObject _leftBottomCorner;
    [SerializeField] private GameObject _rightUpperCorner;

    private Vector2 _whereToSpawn;
    private float _randomX;
    private float _randomY;
    
    protected float ChooseHorizontalPosition()
    {
        _randomX = Random.Range(_leftBottomCorner.transform.position.x, _rightUpperCorner.transform.position.x);
        
        return _randomX;
    }
    
    protected float ChooseVerticalPosition()
    {
        _randomY = Random.Range(_leftBottomCorner.transform.position.y, _rightUpperCorner.transform.position.y);
        
        return _randomY;
    }
}
