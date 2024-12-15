public class Experience
{
    private ExperienceView _experienceView;
    private ExperienceModel _experienceModel;

    public Experience(ExperienceView experienceView, float maxValue)
    {
        _experienceView = experienceView;
        _experienceModel = new ExperienceModel(_experienceView, maxValue);
    }

    public void AddExperience(float experienceAmount)
    {
        _experienceModel.ChangeValue(experienceAmount);
    }
}
