using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ActivateWorm()
    {
        gameObject.SetActive(true);
    }


    public void AnimationDead()
    {
        animator.SetBool(GameConstants.WORM_ANIM_COND_DEAD, true);
    }

    public IEnumerator ShootProjectile()
    {
        animator.SetBool(GameConstants.WORM_ANIM_COND_SHOOTPROJECTILE, true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(GameConstants.WORM_ANIM_COND_SHOOTPROJECTILE, false);
    }
}
