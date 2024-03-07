using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrogExpirienceController : MonoBehaviour
{
    [SerializeField] private Image _exp;
    [SerializeField] private int _expirience;
    public static float _currentExpirience = 0;



    private void Update()
    {
        if (_currentExpirience == _expirience)
        {
            SceneManager.LoadScene(4);
        }
        ExpDisplay();
    }
    
    private void ExpDisplay()
    {
        _exp.fillAmount = _currentExpirience / _expirience;
    }
}
