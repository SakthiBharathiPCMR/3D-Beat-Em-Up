using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnimation;
    private Rigidbody rigidbodyEnemy;
    private Transform playerTarget;
    public float chasePlayerAfterAttack = 0.5f;
    private float defaultAttackTime = 2f;
    private float currentAttackTime;
    private bool followPlayer, attackPlayer;

    public float speed = 5f;
    public float attackDistance = 1f;


    private void Awake()
    {
        enemyAnimation = GetComponentInChildren<CharacterAnimation>();
        rigidbodyEnemy = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }


    private void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void Update()
    {
        Attack();
    }


    private void FollowTarget()
    {
        if (!followPlayer) return;

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            rigidbodyEnemy.velocity = transform.forward;
            if (rigidbodyEnemy.velocity.sqrMagnitude != 0)
            {
                enemyAnimation.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            rigidbodyEnemy.velocity = Vector3.zero;
            enemyAnimation.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }

    private void Attack()
    {
        if (!attackPlayer) return;

        currentAttackTime += Time.deltaTime;

        if (currentAttackTime > defaultAttackTime)
        {
            enemyAnimation.EnemyAttack(Random.Range(0, 3));
            currentAttackTime = 0f;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }










}
