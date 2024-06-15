using System;
using UnityEngine;
using UnityEngine.Events;

public class ExperienceChanger : MonoBehaviour
{
    [SerializeField] private GameObject _endLevelUI;
    [SerializeField] private float _amountExperience = 100;
    [SerializeField] private float _percentToMultiplier = 0.7f;

    private const int _gainedExperienceMultiplier = 2;

    private ScaleChanger _scaleChanger;
    private float _currentExperience;

    public UnityEvent<float> OnExperienceChanged;

    private void Awake()
    {
        _scaleChanger = GetComponent<ScaleChanger>();
        _currentExperience = 0;
    }

    public float GetCurrentExperiencePercent()
    {
        return _currentExperience / _amountExperience;
    }

    public void GainExperience(int gainedExperience)
    {
        if (gainedExperience < 0)
            throw new ArgumentOutOfRangeException(nameof(gainedExperience));

        if (GetCurrentExperiencePercent() >= _percentToMultiplier)
            gainedExperience *= _gainedExperienceMultiplier;

        _currentExperience += gainedExperience;
        _scaleChanger.ChangeScale(gainedExperience);
        OnExperienceChanged.Invoke(GetCurrentExperiencePercent());

        if (_currentExperience >= _amountExperience)
            CompleteLevel();
    }

    private void CompleteLevel()
    {
        _endLevelUI.SetActive(true);
    }
}
