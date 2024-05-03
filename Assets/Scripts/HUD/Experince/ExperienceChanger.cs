using UnityEngine;
using UnityEngine.Events;

public class ExperienceChanger : MonoBehaviour
{
    [SerializeField] private float _amountExperience = 100;
    private ScaleChanger _scaleChanger;
    private float _currentExperience;

    public UnityEvent<float> OnExperienceChanged;

    private void Awake()
    {
        _scaleChanger = GetComponent<ScaleChanger>();
        _currentExperience = 0;
    }

    public float GetTheCurrentExperiencePercentage()
    {
        return _currentExperience / _amountExperience;
    }
    
    public void GainExperience(int gainedExperience)
    {
        if (_currentExperience >= 70)
        {
            gainedExperience *= 2;
        }
        
        _currentExperience += gainedExperience;
        _scaleChanger.ChangeScale(gainedExperience);
        OnExperienceChanged.Invoke(GetTheCurrentExperiencePercentage());
    }
}
