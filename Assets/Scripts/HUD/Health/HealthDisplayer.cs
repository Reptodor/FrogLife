using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        
        _health.OnHealthChanged.AddListener(health =>
        {
            _healthBar.fillAmount = health;
        });
    }
}
