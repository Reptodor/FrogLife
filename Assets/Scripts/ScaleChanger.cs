using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float _scaleMultiple = 1;
    
    public void ScaleChanging(float changeAmount)
    {
        transform.localScale = new Vector3(transform.localScale.x + changeAmount * _scaleMultiple, transform.localScale.y + 
            changeAmount * _scaleMultiple, transform.localScale.z + changeAmount * _scaleMultiple);
        
    }
    public void ExtraScaleChanging(float changeAmount)
    {
        transform.localScale = new Vector3(transform.localScale.x + changeAmount * _scaleMultiple, transform.localScale.y + 
            changeAmount * _scaleMultiple, transform.localScale.z + changeAmount * _scaleMultiple);
        
    }
}
