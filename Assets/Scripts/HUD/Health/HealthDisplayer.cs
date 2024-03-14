using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    
    private void Update()
    {
        ShowHealthBar();    
    }
    
    private void ShowHealthBar()
    {
        _healthBar.fillAmount = _health.CalculateTheDifferenceHealth();
    }
}
