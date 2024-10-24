using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float health = 100f;
    public bool isPlayer;

    private CharacterAnimation characterAnimation;
    private EnemyMovement enemyMovement;
    private HealthUI healthUI;

    private bool isDead;

    private void Awake()
    {
        characterAnimation = GetComponentInChildren<CharacterAnimation>();

        if(isPlayer)
        healthUI = GetComponent<HealthUI>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (isDead) return;

        health -= damage;
        //display health UI

        if (isPlayer)
            healthUI.DisplayHealth(health);

        if(health<=0)
        {
            characterAnimation.Death();
            isDead = true;

            if(isPlayer)
            {
                GameObject.FindWithTag(TagManager.ENEMY_TAG).
                    GetComponent<EnemyMovement>().enabled = false;
            }
            return;
        }

        if(!isPlayer)
        {
            if(knockDown)
            {
                if(Random.Range(0,2)>0)
                {
                    characterAnimation.KnockDown();
                }    
            }
            else
            {
                if(Random.Range(0,3)>1)
                {
                    characterAnimation.Hit();
                }
            }
        }
    }
}
