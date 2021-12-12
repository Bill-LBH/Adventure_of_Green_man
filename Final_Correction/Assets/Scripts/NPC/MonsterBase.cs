using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private int damage1 = 1;
    [SerializeField] private int damage2 = 1;
    [SerializeField] private int damage3 = 1;
    [SerializeField] private int Hurt = 1;
    [SerializeField] private bool isDamageable;
    [SerializeField] private float attackDelay = 1f;
    private float nextAttackTime=0f;
    private Animator animator;
    private readonly int attackParameter = Animator.StringToHash("Attack");
    private readonly int stopParameter = Animator.StringToHash("Stop");
    private readonly int dieParameter = Animator.StringToHash("Die");
    private Health health;
    private SpriteRenderer spriteRenderer;
    private Collider2D damageAreaCollider2D;
    private void Start()
    {
        health = GetComponent<MonsterHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        damageAreaCollider2D = GetComponentInChildren<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(attackParameter);
            other.GetComponent<Health>().TakeDamage(Hurt);
        }
        if (other.CompareTag("PlayerHurt"))
        {
            animator.SetTrigger(attackParameter);
            GameObject fu = other.transform.parent.gameObject;
            fu.GetComponent<Health>().TakeDamage(Hurt);
        }
        if (other.CompareTag("Bullet"))
        {
            TakeDamage1();
        }
        if (other.CompareTag("Bullet 1"))
        {
            TakeDamage2();
        }
        if (other.CompareTag("Bullet 2"))
        {
            TakeDamage3();
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
        animator.SetTrigger(attackParameter);
        if (Time.time > nextAttackTime)  //Actual time in the game GREATER THAN fire rate
        {
            other.GetComponent<Health>().TakeDamage(Hurt);
            nextAttackTime = Time.time + attackDelay;
        }
        animator.SetTrigger(stopParameter);
        }
        if (other.CompareTag("PlayerHurt"))
        {
            animator.SetTrigger(attackParameter);
            GameObject fu = other.transform.parent.gameObject;
            if (Time.time > nextAttackTime)  //Actual time in the game GREATER THAN fire rate
            {
                fu.GetComponent<Health>().TakeDamage(Hurt);
                nextAttackTime = Time.time + attackDelay;
            }
            animator.SetTrigger(stopParameter);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerHurt"))
        {
            animator.SetTrigger(stopParameter);
        }
    }

    private void TakeDamage1()
    {
        health.TakeDamage(damage1);
    }
    private void TakeDamage2()
    {
        health.TakeDamage(damage2);
    }
    private void TakeDamage3()
    {
        health.TakeDamage(damage3);
    }
    public void DieAni()
    {
        animator.SetTrigger(dieParameter);
    }
}
