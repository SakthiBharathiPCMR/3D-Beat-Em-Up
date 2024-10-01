using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2,

}
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation characterAnim;

    private bool activateTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;
    private ComboState currentComboState;

    private void Awake()
    {
        characterAnim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
    }

    private void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    private void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState == ComboState.PUNCH_3 ||
                currentComboState == ComboState.KICK_1 ||
                currentComboState == ComboState.KICK_2)
                return;

            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.PUNCH_1)
            {
                characterAnim.Punch_1();
            }
            if (currentComboState == ComboState.PUNCH_2)
            {
                characterAnim.Punch_2();
            }
            if (currentComboState == ComboState.PUNCH_3)
            {
                characterAnim.Punch_3();
            }

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentComboState == ComboState.PUNCH_3 ||
                currentComboState == ComboState.KICK_2)
                return;
            if (currentComboState == ComboState.NONE ||
                currentComboState == ComboState.PUNCH_1 ||
                currentComboState == ComboState.PUNCH_2)
            {
                currentComboState = ComboState.KICK_1;
            }
            else if (currentComboState == ComboState.KICK_1)
            {
                currentComboState = ComboState.KICK_2;
            }

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.KICK_1)
            {
                characterAnim.Kick_1();
            }
            if (currentComboState == ComboState.KICK_2)
            {
                characterAnim.Kick_2();
            }
        }
    }

    private void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
