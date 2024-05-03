using UnityEngine;
using UnityEngine.UI;

public class Education : MonoBehaviour
{
    [SerializeField] private AudioSource[] _dubbings;
    [SerializeField] private GameObject[] _things;
    [SerializeField] private GameObject _educationPanel;
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private Text _textOfEducation;
    [SerializeField] private string[] _texts;
    private int _stepIndex = 0;
    private int _dubbingIndex;
    
    private void Awake() => _stepIndex = 0;

    private void Update()
    {
        ShowEducation();
    }

    public void StartListenDubbing()
    {
        _dubbings[_dubbingIndex].Play();
    }

    public void StopListenDubbing()
    {
        _dubbings[_dubbingIndex].Stop();
    }
    
    private void ShowEducation()
    {
        _textOfEducation.text = _texts[_stepIndex];
        if (_stepIndex > 0 && _stepIndex < _things.Length)
            _things[_stepIndex - 1].SetActive(false);
        if (_stepIndex < _things.Length)
            _things[_stepIndex].SetActive(true);
        
        
        if (_stepIndex + 1 < _texts.Length)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _stepIndex++;
                _dubbingIndex++;
                _dubbings[_dubbingIndex - 1].Stop();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneLoader.SceneLoaderInstance.LoadNextScene();
            }
        }
    }
}
