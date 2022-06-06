using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayersMovement),typeof(PlayerJumpStates),typeof(PlayerJump))]
public class PlayerMoveState : MonoBehaviour
{
    public static float staticSpeed;
    public static float staticJumpSpeed;
    public static Rigidbody2D rb;
    public static bool movement3d;

    [Header("TypeOfMovement")]
    public bool Is3Dimensional;

    [Header("Player's Speed")]
    [Tooltip("Speed*time.deltaTime")]
    [Range(1,10)]
    public float speed;
    [Header("Players Jump Speed")]
    [Range(200, 1000)]
    public float jumpSpeed;

    private Collider2D playersCollider;

    public static MainControllsAcrossPlatforms inputActions;

    public enum MovementAvanability
    {
        Active,
        Disabled
    }
    public delegate void ChangeMovement(MovementAvanability movementStates);
    public static event ChangeMovement OnMovementChange;

    public enum PlayerJumpStates
    {
        onGround,
        onAir

    }
    public delegate void ChangeJump(PlayerJumpStates jumpStates);
    public static event ChangeJump OnJumpStateChange;
    

    private void Awake()
    {
        inputActions = new MainControllsAcrossPlatforms();
        staticSpeed = speed;
        staticJumpSpeed = jumpSpeed;
        rb = GetComponent<Rigidbody2D>();
        playersCollider = gameObject.GetComponent<Collider2D>();
    }
    void Start()
    {
        inputActions.MovementAndInteractionsKit.Enable();
        DialogueManagerStates.OnStateChange += AccordingToDialogueChangeState;
        OnMovementChange += MovementEnabler;
        movement3d = Is3Dimensional;
    }
    private void OnCollisionEnter(Collision collision)//for 3d collisions
    {
        if (collision.gameObject.GetComponent<NpcMovementManager>() != null)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//for 2dCollisions
    {
        if (collision.gameObject.GetComponent<NpcMovementManager>() != null)
        {
            Physics2D.IgnoreCollision(playersCollider, collision.gameObject.GetComponent<Collider2D>());
        }
    }
    public static void ChangeMovementAvanability(MovementAvanability movementStates)
    {
        if (OnMovementChange != null)
        {
            OnMovementChange(movementStates);
        }
    }
    public static void ChangeJumpState(PlayerJumpStates jumpState)
    {
        if (OnJumpStateChange != null)
        {
            OnJumpStateChange(jumpState);
        }
    }

    private void AccordingToDialogueChangeState(DialogueManagerStates.ManagerStates managerStates)
    {
        switch (managerStates)
        {
            case DialogueManagerStates.ManagerStates.active:
                PlayerMoveState.ChangeMovementAvanability(MovementAvanability.Disabled);
                break;
            case DialogueManagerStates.ManagerStates.disabled:
                PlayerMoveState.ChangeMovementAvanability(MovementAvanability.Active);
                break;
        }
    }
    private void MovementEnabler(MovementAvanability movementStates)
    {
        switch (movementStates)
        {
            case MovementAvanability.Active:
                inputActions.MovementAndInteractionsKit.Enable();
                break;
            case MovementAvanability.Disabled:
                inputActions.MovementAndInteractionsKit.Disable();
                break;
        }
    }
}
