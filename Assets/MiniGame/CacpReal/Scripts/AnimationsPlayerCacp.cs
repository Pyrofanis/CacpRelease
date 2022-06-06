using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class AnimationsPlayerCacp : MonoBehaviour
{
    public enum AnimationState
    {
        walking, idle
    }
    private AnimationState currentState;
    public enum Direction
    {
        left, right
    }
    private Direction currentDirection;

    private Vector2 initialScale;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        initialScale = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        Updaters();
        Applier();
    }
    private void Updaters()
    {
        StateUpdter();
        UpdateDirection();
    }
    private void StateUpdter()
    {
        if (PlayersMovement.MovementDirection().x != 0)
        {
            currentState = AnimationState.walking;
        }
        else
        {
            currentState = AnimationState.idle;
        }
    }
    private void UpdateDirection()
    {
        if (PlayersMovement.MovementDirection().x >= 0)
        {
            currentDirection = Direction.right;
        }
        else
        {
            currentDirection = Direction.left;

        }
    }
    private void Applier()
    {
        ApplyClip(currentState);
        ApplyDirection(currentDirection);
    }
    private void ApplyClip(AnimationState animationState)
    {
        switch (animationState)
        {
            case AnimationState.idle:
                animator.SetBool("Walking", false);
                break;
            case AnimationState.walking:
                animator.SetBool("Walking", true);
                break;
        }
    }
    private void ApplyDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.left:
                transform.localScale =new Vector2(-initialScale.x,1);
                break;
            case Direction.right:
                transform.localScale = new Vector2(initialScale.x, 1);
                break;
        }
    }
}
