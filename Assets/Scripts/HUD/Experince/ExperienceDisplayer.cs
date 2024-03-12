using UnityEngine;
using UnityEngine.UI;

public class ExperienceDisplayer : MonoBehaviour
{
    [SerializeField] private Image _experienceBar;
    private ExperienceChanger _experienceChanger;
    

    private void Update()
    {
        _experienceChanger = GetComponent<ExperienceChanger>();
        ShowExpBar();
    }
    
    public void ShowExpBar()
    {
        _experienceBar.fillAmount = _experienceChanger.CalculateTheDifferenceExperience();
    }
}
