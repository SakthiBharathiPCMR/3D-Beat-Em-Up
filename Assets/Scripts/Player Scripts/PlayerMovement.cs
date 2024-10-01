using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation playerAnimation;
    private Rigidbody rbPlayer;
    private float rotationY = -90f;
    public float walkSpeed = 3f;
    public float zSpeed = 1.5f;
    public float rotationSpeed = 15f;

    private void Awake()
    {
        rbPlayer = this.GetComponent<Rigidbody>();
        playerAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    private void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    private void FixedUpdate()
    {
        DetectMovement();
    }
    private void DetectMovement()
    {
        rbPlayer.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed),
            rbPlayer.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-zSpeed));
    }

    private void RotatePlayer()
    {
        if ((Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0))
        {
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }
        else if ((Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0))
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
        }
    }

    private void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 ||
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
    }


}
