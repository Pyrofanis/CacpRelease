using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
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
    public delegate void ChangeEmotion(Emotions emotions);
    public event ChangeEmotion OnEmotionChange;

    [System.Serializable]
    public struct ResponseAndEmotion
    {
        [Header("Players_Responses")]
        [TextArea]
        public string currentResponse;
        [Header("Player Emotion")]
        [Tooltip("Emotion Facial animation to play")]
        public PlayerStates.Emotions currentEmotions;
        public ResponseAndEmotion(string newString, PlayerStates.Emotions newEmo)
        {
            this.currentEmotions = newEmo;
            this.currentResponse = newString;
        }
    }
    private void ChangeEmotionState(Emotions emotions)
    {
        if (OnEmotionChange != null)
        {
            OnEmotionChange(emotions);
        }
    }
}
