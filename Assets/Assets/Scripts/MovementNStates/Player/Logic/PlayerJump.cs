using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool canJump;
    void Start()
    {
        PlayerMoveState.inputActions.MovementAndInteractionsKit.JumpKey.performed += _ => JumpAction(canJump);
        PlayerMoveState.OnJumpStateChange += JumpIfPossible;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("ground"))
        {
            PlayerMoveState.ChangeJumpState(PlayerMoveState.PlayerJumpStates.onGround);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("ground"))
        {
            PlayerMoveState.ChangeJumpState(PlayerMoveState.PlayerJumpStates.onGround);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("ground"))
        {
            PlayerMoveState.ChangeJumpState(PlayerMoveState.PlayerJumpStates.onAir);
        }
    }

    private void JumpIfPossible(PlayerMoveState.PlayerJumpStates jumpStates)
    {
        switch (jumpStates)
        {
            case PlayerMoveState.PlayerJumpStates.onGround:
                canJump = true;
                break;
            case PlayerMoveState.PlayerJumpStates.onAir:
                canJump = false;
                break;
        }

    }

    private void JumpAction(bool onground)
    {   
        if (onground)
        PlayerMoveState.rb.AddForce(Vector3.up*PlayerMoveState.staticJumpSpeed);
    }

}
