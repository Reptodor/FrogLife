using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private AudioSource _takingDamageScream;
    [SerializeField] private float _amountHealth;
    private float _currentHealth;

    public UnityEvent<float> OnHealthChanged;

    private void Awake()
    {
        _currentHealth = _amountHealth;
        _loseMenu.SetActive(false);
    }

    public float GetTheCurrentHealthPercentage()
    {
        return _currentHealth / _amountHealth;
    }
    
    public void RecieveDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));
        
        _currentHealth -= damage; 
        _takingDamageScream.Play();
        OnHealthChanged.Invoke(GetTheCurrentHealthPercentage());

        if (_currentHealth <= 0)
        {
            _loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
