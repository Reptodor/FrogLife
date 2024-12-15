using UnityEngine;
using UnityEngine.UI;

public class ExperienceView : MonoBehaviour
{
    [SerializeField] private Image _barFilling;
    private EndMenu _endMenu;

    private void OnValidate()
    {
        if(_barFilling == null)
            _barFilling = GetComponent<Image>();
    }
 
    private void Awake()
    {
        _endMenu = FindAnyObjectByType<EndMenu>();
    }

    public void ChangeBarFilling(float valuePercentage)
    {
        _barFilling.fillAmount = valuePercentage;
    }

    public void DisplayEndMenu()
    {
        _endMenu.ShowPanel();
    }
}
