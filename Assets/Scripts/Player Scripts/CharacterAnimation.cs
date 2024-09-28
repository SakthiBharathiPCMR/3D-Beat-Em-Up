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
}
