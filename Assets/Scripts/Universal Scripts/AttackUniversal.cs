using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer, isEnemy;
    public GameObject hitFxPrefab;




    private void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hits.Length > 0)
        {

            if (isPlayer)
            {
                Vector3 hitFxPos = hits[0].transform.position;
                hitFxPos.y += 1.3f;

                if (hits[0].transform.forward.x > 0)
                {
                    hitFxPos.x += 0.3f;
                }
                else if (hits[0].transform.forward.x < 0)
                {
                    hitFxPos.x -= 0.3f;
                }

                Instantiate(hitFxPrefab, hitFxPos, Quaternion.identity);

                if (gameObject.CompareTag(TagManager.LEFT_ARM_TAG) ||
                    gameObject.CompareTag(TagManager.LEFT_LEG_TAG))
                {
                    hits[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hits[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }

            }
            if (isEnemy)
            {
                hits[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }
            gameObject.SetActive(false);
        }
    }

}
