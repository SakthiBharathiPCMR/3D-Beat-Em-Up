using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnimation;
    private Rigidbody rigidbodyEnemy;
    private Transform playerTarget;
    private float chasePlayerAfterAttack = 1f;
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

}
