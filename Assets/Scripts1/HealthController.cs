using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _healthAmount;
    [SerializeField] private int _currentScene; 

    private void Update()
    {
        ShowHealthBar();
        CheckingDeath();
    }

    private void CheckingDeath()
    {
        if(_healthAmount == 0) SceneManager.LoadScene(_currentScene);
    }
    
    private void ShowHealthBar()
    {
        _healthBar.fillAmount = _healthAmount / 5;
    }

    public void RecieveDamage(int damage)
    {
        _healthAmount -= damage;
    }
}
