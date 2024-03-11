using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] _tutorials;
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
        Time.timeScale = 0;
        _tutorials[_tutorialIndex].SetActive(true);
    }

    private void CloseTutorial()
    {
        if (Input.anyKey)
        {
            _tutorials[_tutorialIndex].SetActive(false);
            
            Debug.Log("dsadsa");
            
            if (_tutorialIndex < _tutorials.Length - 1)
            {
                ChooseTutorialIndex();
            }
            else
            {
                Time.timeScale = 1;
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
