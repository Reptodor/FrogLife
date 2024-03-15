using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float _amountHealth;
    [SerializeField] private int _currentScene;
    private float _currentHealth;


    private void Awake()
    {
        _currentHealth = _amountHealth;
    }

    private void Update()
    {
        CheckingDeath();
    }
    
    public float CalculateTheDifferenceHealth()
    {
        return _currentHealth / _amountHealth;
    }
    
    public void RecieveDamage(int damage)
    {
        _currentHealth -= damage;
    }
    
    private void CheckingDeath()
    {
        if(_currentHealth == 0) SceneManager.LoadScene(_currentScene);
    }
}
