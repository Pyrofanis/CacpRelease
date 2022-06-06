using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + MovementDirection(), PlayerMoveState.staticSpeed * Time.deltaTime);
    }
    public static Vector3 MovementDirection()
    {
        float movementX = PlayerMoveState.inputActions.MovementAndInteractionsKit.MovementX.ReadValue<float>();
        float movementZ = PlayerMoveState.inputActions.MovementAndInteractionsKit.MovementZ.ReadValue<float>();
        if (PlayerMoveState.movement3d)
        {
            return new Vector3(movementX, 0, movementZ);
        }
        else
        {
            return new Vector2(movementX, 0);
        }
    }
}
