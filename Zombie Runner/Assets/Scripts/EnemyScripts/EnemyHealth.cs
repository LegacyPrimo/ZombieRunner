using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 10f;
    [SerializeField] private Animator animator;

    private Enemy enemyParent;

    private void Awake()
    {
        enemyParent = GetComponent<Enemy>();
        animator = GetComponentInChildren<Animator>();
    }

    public void ReduceHitPoints(float damage) 
    {
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");

        if (hitPoints <= 0) 
        {
            animator.SetBool("isDead", true);
            enemyParent.GetEnemyState(EnemyState.dead);
            Destroy(gameObject, 2f);
        }
    }
}
