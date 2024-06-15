using UnityEngine;

public class Shore : MonoBehaviour
{
    [SerializeField] private GameObject _endOfGamePanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<TadpoleMovement>() != null && other.gameObject.GetComponent<ExperienceChanger>().GetCurrentExperiencePercent() >= 1)
            _endOfGamePanel.SetActive(true);
    }
}
