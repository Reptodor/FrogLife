using System;

public class ExperienceModel
{
    private ExperienceView _experienceView;
    private float _value;
    private float _maxValue;

    public ExperienceModel(ExperienceView experienceView, float maxValue)
    {
        if (experienceView == null)
            throw new ArgumentNullException(nameof(experienceView));

        _experienceView = experienceView;

        if(maxValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        
        _maxValue = maxValue;
    }

    public void ChangeValue(float changeAmount)
    {
        if(changeAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(changeAmount));

        _value += changeAmount;
        _experienceView.ChangeBarFilling(ExperiencePercentage());

        if(_value >= _maxValue)
            _experienceView.DisplayEndMenu();
    }

    private float ExperiencePercentage() => _value / _maxValue;
}
