using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] _tutorials;
    [SerializeField] private GameObject[] _gameObjects;
    private int _tutorialIndex;


    private void Awake()
    {
        ShowTutorial();
    }
    
    private void Update()
    {
        CloseTutorial();
    }

    private void ShowTutorial()
    {
        foreach (var gameObject in _gameObjects)
        {
            gameObject.SetActive(false);
        }
        _tutorials[_tutorialIndex].SetActive(true);
    }

    private void CloseTutorial()
    {
        if (Input.anyKey)
        {
            _tutorials[_tutorialIndex].SetActive(false);
            
            if (_tutorialIndex < _tutorials.Length - 1)
            {
                ChooseTutorialIndex();
            }
            else
            {
                foreach (var gameObject in _gameObjects)
                {
                    gameObject.SetActive(true);
                }
                Destroy(gameObject);
            }
        }
    }
    
    private void ChooseTutorialIndex()
    {
        ++_tutorialIndex; 
        ShowTutorial();
    }
}
