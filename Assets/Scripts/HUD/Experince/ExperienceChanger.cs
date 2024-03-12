using UnityEngine;

public class ExperienceChanger : MonoBehaviour
{
    private ScaleChanger _scaleChanger;


    [SerializeField] private float _amountExperience = 100;
    private float _currentExperience;
    
    private void Awake()
    {
        _scaleChanger = GetComponent<ScaleChanger>();
    }

    public float CalculateTheDifferenceExperience()
    {
        return _currentExperience / _amountExperience;
    }
    
    public void GainingExperience(int gainedExperience)
    {

        if (_currentExperience < 70)
        {
            _currentExperience += gainedExperience;
            _scaleChanger.ScaleChanging(gainedExperience);
        }
        else
        {
            _currentExperience += gainedExperience * 2;
            _scaleChanger.ScaleChanging(gainedExperience * 2f);
        }
    }
}
