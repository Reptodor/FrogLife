using UnityEngine;
using UnityEngine.UI;

public class ExpirienceController : MonoBehaviour
{
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private GameObject _textInFinish;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private bool _isFirtsLevel;
    [SerializeField] private Image _expBar;
    [SerializeField] private float _expAmount = 100;
    [SerializeField] private float _expCount;
    private ScaleChanger _scaleChanger;
    
    
    private void Start()
    {
        _scaleChanger = GetComponent<ScaleChanger>();
    }
    
    private void Update()
    {
        ShowExpBar();

        if (_isFirtsLevel)
        {
            if (_expCount >= _expAmount) _endGameMenu.SetActive(true);
        }

        if (!_isFirtsLevel)
        {
            if (_expCount >= _expAmount)
            {
                _textInFinish.SetActive(true);
                _arrow.SetActive(true);
            }
        }
    }
    
    private void ShowExpBar()
    {
        _expBar.fillAmount = _expCount / _expAmount;
    }
    
    public void GainingExpirience(int gainedExp)
    {

        if (_expCount < 70)
        {
            _expCount += gainedExp;
            _scaleChanger.ScaleChanging(gainedExp);
        }
        else
        {
            _expCount += gainedExp * 2;
            _scaleChanger.ExtraScaleChanging(gainedExp * 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_expCount >= _expAmount && other.gameObject.CompareTag("Finish"))
        {
            Destroy(_textInFinish);
            Destroy(_arrow);
            _endGameMenu.SetActive(true);
        }
    }
}
