using UnityEngine;
using UnityEngine.UI;

public class ExperienceDisplayer : MonoBehaviour
{
    [SerializeField] private Image _experienceBar;
    private ExperienceChanger _experienceChanger;
    
    private void Awake()
    {
        _experienceChanger = GetComponent<ExperienceChanger>();
        _experienceChanger.OnExperienceChanged.AddListener((experience) =>
        {
            _experienceBar.fillAmount = experience;
        });
    }
}
