using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint,
         leftLegAttackPoint, rightLegAttackPoint;

    public float standUpTime = 2;

    private CharacterAnimation characterAnimation;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whooshSound, fallSound, groundHitSound, deadSound;

    private EnemyMovement enemyMovement;

    private ShakeCamera shakeCamera;
    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }

        shakeCamera = GameObject.FindWithTag(TagManager.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();

    }

    private void LeftArmAttackOn()
    {
        leftArmAttackPoint.gameObject.SetActive(true);
    }

    private void LeftArmAttackOff()
    {
        leftArmAttackPoint.gameObject.SetActive(false);
    }

    private void RightArmAttackOn()
    {
        rightArmAttackPoint.gameObject.SetActive(true);
    }

    private void RightArmAttackOff()
    {
        rightArmAttackPoint.gameObject.SetActive(false);
    }

    private void LeftLegAttackOn()
    {
        leftLegAttackPoint.gameObject.SetActive(true);
    }

    private void LeftLegAttackOff()
    {
        leftLegAttackPoint.gameObject.SetActive(false);
    }

    private void RightLegAttackOn()
    {
        rightLegAttackPoint.gameObject.SetActive(true);
    }

    private void RightLegAttackOff()
    {
        rightLegAttackPoint.gameObject.SetActive(false);
    }

    private void TagLeftArm()
    {
        leftArmAttackPoint.tag = TagManager.LEFT_ARM_TAG;
    }

    private void UnTagLeftArm()
    {
        leftArmAttackPoint.tag = TagManager.UNTAGGED_TAG;
    }

    private void TagLeftLeg()
    {
        leftLegAttackPoint.tag = TagManager.LEFT_LEG_TAG;
    }

    private void UnTagLeftLeg()
    {
        leftLegAttackPoint.tag = TagManager.UNTAGGED_TAG;
    }

    private void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    private IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTime);
        characterAnimation.StandUp();
    }

    public void AttackFxSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }

    private void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = deadSound;
        audioSource.Play();

    }

    private void EnemyKnockDown()
    {
        audioSource.volume = 1f;
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    private void EnemyHitGround()
    {
        audioSource.volume = 1f;
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }


    private void DisableMovement()
    {
        enemyMovement.enabled = false;
        transform.parent.gameObject.layer = 0;
    }

    private void EnableMovement()
    {
        enemyMovement.enabled = true;
        transform.parent.gameObject.layer = 7;

    }


    private void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    private void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    private void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }






}
