using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState 
{
    alive,
    dead
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private PlayerHealth targetTransform;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float chaseRange = 6f;
    [SerializeField] private float damage;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float distanceToTarget = Mathf.Infinity;

    private bool isProvoked = false;

    public EnemyState GetEnemyState(EnemyState enemyState) 
    {
        return enemyState;
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget() 
    {
        if (enemyState == EnemyState.dead) return;

        distanceToTarget = Vector3.Distance(targetTransform.transform.position, transform.position);

        if (isProvoked) 
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

        else { return; }

    }

    private void EngageTarget() 
    {
        FaceToTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("attack", false);
            ChaseTarget();
            animator.SetBool("move", true);
        }

        else if (distanceToTarget <= navMeshAgent.stoppingDistance) 
        {
            animator.SetBool("attack", true);
        }
    }

    private void ChaseTarget() 
    {
        navMeshAgent.SetDestination(targetTransform.transform.position);
    }

    public void AttackTarget() 
    {
        if (targetTransform == null) { return;}
       
        targetTransform.CheckHealth(damage);
        
    }

    private void FaceToTarget() 
    {
        Vector3 direction = (targetTransform.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * turnSpeed);
    }

    public void OnDamageTaken() 
    {
        isProvoked = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
