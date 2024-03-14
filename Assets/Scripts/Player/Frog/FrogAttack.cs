using UnityEngine;

public class FrogAttack : MonoBehaviour
{
    private ExperienceChanger _experienceChanger;
    public static FrogAttack FrogAttackInstance;
    public bool CanAttack = true;


    private void Awake()
    {
        _experienceChanger = GetComponentInParent<ExperienceChanger>();
    }
    
    private void Update()
    {
        Attack();
        FrogAttackInstance = this;
    }
    
    private void Attack()
    {
        if (Input.GetButtonDown("Fire1") && CanAttack)
        {
            PlayerAnimation.PlayerAnimationInstance.AttackAnimating();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CaterpillarMovement>() != null)
        {
            CaterpillarSpawner.Spawned--;
            Destroy(other.gameObject);
            _experienceChanger.GainingExperience(1);
        }
    }
}
