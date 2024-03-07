using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Transform _shore;
    [SerializeField] private GameObject _arrow;
    
    private void Update()
    {
        Following();

        _arrow.transform.rotation = transform.rotation;
    }

    private void Following()
    {
        transform.LookAt(_shore);
    }
}
