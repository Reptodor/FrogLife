using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    public bool IsMoving;
    public static PlayerAnimation PlayerAnimationInstance;
    private void Awake()
    {
        PlayerAnimationInstance = this;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        WalkAnimating();
    }
    
    public void WalkAnimating()
    {
        _animator.SetBool("IsMoving", IsMoving);
    }

    public void AttackAnimating()
    {
        _animator.SetTrigger("Attack");
    }
}
