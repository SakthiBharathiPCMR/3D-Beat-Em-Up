using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public float deactivateTime = 2f;

    private void Start()
    {
        Invoke("DeactivateAfterTime", deactivateTime);
    }

    private void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }


}
