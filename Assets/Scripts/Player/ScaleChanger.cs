using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float _scaleMultiple = 1;
    
    public void ChangeScale(float changeAmount)
    {
        Vector3 scale = transform.localScale;
        float unitOfChange = changeAmount * _scaleMultiple;
        transform.localScale = new Vector3(scale.x + unitOfChange, scale.y + unitOfChange, scale.z + unitOfChange);
    }
}
