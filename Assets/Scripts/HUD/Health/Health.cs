using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private AudioSource _takingDamageScream;
    [SerializeField] private float _amountHealth;
    private float _currentHealth;

    public UnityEvent<float> OnHealthChanged;

    private void Awake() => _currentHealth = _amountHealth;
    
    public float GetTheCurrentHealthPercentage()
    {
        return _currentHealth / _amountHealth;
    }
    
    public void RecieveDamage(int damage)
    {
        _currentHealth -= damage; 
        _takingDamageScream.Play();
        OnHealthChanged.Invoke(GetTheCurrentHealthPercentage());
        if(_currentHealth <= 0) SceneLoader.SceneLoaderInstance.RestartCurrentScene();
    }
}
