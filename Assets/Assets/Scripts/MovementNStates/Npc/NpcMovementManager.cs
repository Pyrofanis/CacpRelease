using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovementManager : MonoBehaviour
{

    private NpcStates npcStates;
    private PlayerMoveState playerMove;
    [SerializeField]
    [Range(2, 10)]
    private float distance;
    [SerializeField]
    [Range(2, 40)]
    private float speed;
    [SerializeField]
    [Range(2, 40)]
    private float _MaxTimer;
    [SerializeField]
    [Range(2, 40)]
    private float _MinTimer;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        npcStates = GetComponent<NpcStates>();
        playerMove = GameObject.FindObjectOfType<PlayerMoveState>();
        npcStates.OnMovementChange += WhenToMove;
    }

    private void WhenToMove(NpcStates.MovementStates movementStates)
    {
        switch (movementStates)
        {
            case NpcStates.MovementStates.move:
                Movement();
                break;
        }
    }
    private void Breaks()
    {
        if (Vector2.Distance(transform.position, playerMove.transform.position) <= distance)
        {
            npcStates.ChangeMovementState(NpcStates.MovementStates.stay);
            timer = Random.Range(_MinTimer, _MaxTimer);
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <=0)
            {
                npcStates.ChangeMovementState(NpcStates.MovementStates.move);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Breaks();
    }
    private void Movement()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = playerMove.transform.position;
        transform.position = Vector2.MoveTowards(currentPos, targetPos, Time.deltaTime * speed);
    }


}
