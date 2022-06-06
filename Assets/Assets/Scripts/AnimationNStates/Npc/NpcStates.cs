using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStates : MonoBehaviour
{
    public enum MovementStates
    {
        move,
        stay
    }
    public enum Emotions
    {
        neutral,
        happy,
        sad,
        anxious,
        angry,
        excited,
        laugh,
        satified,
        jelous,
        fear,
        shame,
        guilt,
        talking,
    }
    public enum InteractionsWithPlayer
    {
        hug,
        kiss,
        avoid,
        distance,
        comeCloser
    }
    public enum InteractionsWithEnviroment
    {
        use,
        close,
        move,
        tryToCatch
    }
    public delegate void EmotionStateChange(Emotions emotions);
    public  event EmotionStateChange OnEmotionStateChange;


    public delegate void ChangeState(MovementStates movementStates);
    public event ChangeState OnMovementChange;

    public void ChangeMovementState(MovementStates movementStates)
    {
        if (OnMovementChange != null)
        {
            OnMovementChange(movementStates);
        }
    }
    public  void ChangeEmotions(Emotions emotions)
    {
        if (OnEmotionStateChange != null)
        {
            OnEmotionStateChange(emotions);
        }
    }

}
