using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animatorCharacter;

    private void Awake()
    {
        animatorCharacter = GetComponent<Animator>();
    }

    public void Walk(bool isMove)
    {
        animatorCharacter.SetBool(AnimationTags.MOVEMENT, isMove);
    }

    public void Punch_1()
    {
        animatorCharacter.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }
    public void Punch_2()
    {
        animatorCharacter.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }
    public void Punch_3()
    {
        animatorCharacter.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }
    public void Kick_1()
    {
        animatorCharacter.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }
    public void Kick_2()
    {
        animatorCharacter.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }


    //Enemy Animations

    public void EnemyAttack(int attack)
    {
        if(attack==0)
        {
            animatorCharacter.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }
        if (attack == 1)
        {
            animatorCharacter.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
        }
        if (attack == 2)
        {
            animatorCharacter.SetTrigger(AnimationTags.ATTACK_3_TRIGGER);
        }
    }


    public void PlayIdleAnimation()
    {
        animatorCharacter.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown()
    {
        animatorCharacter.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }
    public void StandUp()
    {
        animatorCharacter.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }
    public void Hit()
    {
        animatorCharacter.SetTrigger(AnimationTags.HIT_TRIGGER);
    }
    public void Death()
    {
        animatorCharacter.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }

}
