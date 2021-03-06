using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon { get; set; }

    Animator animator;
    Vector3 originalPos;
    Color originalColor;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        originalPos = transform.localPosition;
    }

    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);
        animator.runtimeAnimatorController = Pokemon.Base.AnimationController;

        PlayerEnterAnimation();
    }


    public void PlayerEnterAnimation()
    {
        if (!isPlayerUnit)
            transform.localPosition = new Vector3(500f, originalPos.y);

        transform.DOLocalMoveX(originalPos.x, 1f);
    }

    public void PlayAttackAnimation(AnimationCategory animationCategory = AnimationCategory.Physical)
    {
        if (animationCategory == AnimationCategory.Physical)
            animator.SetTrigger("doPhysicalAttack");
        if (animationCategory == AnimationCategory.Projectile)
            animator.SetTrigger("doProjectileAttack");
    }

    public void PlayerHitAnimation()
    {
        animator.SetTrigger("getHit");
    }

    public void PlayFaintAnimation()
    {
        animator.SetTrigger("onDeath");
    }
}