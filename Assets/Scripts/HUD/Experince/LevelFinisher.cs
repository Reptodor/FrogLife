 using UnityEngine;

public class LevelFinisher : MonoBehaviour
{    
    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private GameObject _textInFinish;
    [SerializeField] private bool _isSecondLevel;

    private ExperienceChanger _experienceChanger;
    private Health _health;

    private bool _isExperienceFull;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _experienceChanger = GetComponent<ExperienceChanger>();
        _isExperienceFull = false;
    }
    
    private void Update()
    {
        ExperienceCheck();
        EndOfLevel();

        if (_health.GetTheCurrentHealthPercentage() <= 0)
        {
            Destroy(_textInFinish);
            Destroy(_arrow);
        }
    }

    private void ExperienceCheck()
    {
        if (_experienceChanger.GetTheCurrentExperiencePercentage() >= 1)
        {
            _isExperienceFull = true;
        }
        else
        {
            _isExperienceFull = false;
        }
    }

    private void EndOfLevel()
    {
        if (!_isSecondLevel)
        {
            if (_isExperienceFull)
            {
                _endGameMenu.SetActive(true);
            }
        }
        else
        {
            if (_isExperienceFull)
            {
                _textInFinish.SetActive(true);
                _arrow.SetActive(true);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isExperienceFull && other.gameObject.CompareTag("Finish"))
        {
            Destroy(_textInFinish);
            Destroy(_arrow);
            _endGameMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
