using System;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;


    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            _tutorialPanel.SetActive(false);
        }
    }
}
