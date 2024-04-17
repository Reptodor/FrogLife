using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private AudioSource _takingDamageScream;
    [SerializeField] private float _amountHealth;
    [SerializeField] private int _currentScene;
    private float _currentHealth;


    private void Awake() => _currentHealth = _amountHealth;

    private void Update() => CheckingDeath();
    
    public void RecieveDamage(int damage)
    {
        _currentHealth -= damage; 
        _takingDamageScream.Play();
    }
    
    public float CalculateTheDifferenceHealth()
    {
        return _currentHealth / _amountHealth;
    }
    
    private void CheckingDeath()
    {
        if(_currentHealth == 0) SceneManager.LoadScene(_currentScene);
    }
}
