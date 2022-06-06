using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffectTypes : MonoBehaviour
{
    [System.Serializable]
    public enum TextEffectStates
    {
        tremble,
        wave,
        shake,
        relaxed,
        sad,
        anxious,
        determ,
        none

    }
    [System.Serializable]
    public struct EffectTypeAndEffectiveness
    {
        public TextEffectStates states;
        public float xEffectivity;
        public float yEffectivity;
        public EffectTypeAndEffectiveness(TextEffectStates newState, float newX, float newY)
        {
            this.states = newState;
            this.xEffectivity = newX;
            this.yEffectivity = newY;
        }
    }
    [System.Serializable]
    public struct TypeAndRange
    {
        public string id;
        public EffectTypeAndEffectiveness effectTypeAndEffectiveness;
        public int initialIndex;
        public int linkCharLength;
        public TypeAndRange(string newId, EffectTypeAndEffectiveness newSeffectTypeAndEffectiveness, int NewInitialIndex, int newLength)
        {
            this.id = newId;
            this.effectTypeAndEffectiveness = newSeffectTypeAndEffectiveness;
            this.initialIndex = NewInitialIndex;
            this.linkCharLength = newLength;
        }

    }
    [HideInInspector]
    public List<TypeAndRange> currentActiveLinks;
    [HideInInspector]
    public List<TypeAndRange> generalCharacters;
    [HideInInspector]
    public List<EffectTypeAndEffectiveness> StateNEffects;

    private EffectScriptsManager effectScripts;
    private void Awake()
    {
        effectScripts = GetComponent<EffectScriptsManager>();
    }
    private void Start()
    {
        AddToListCurrentAvainableEffects();
    }
    private void AddToListCurrentAvainableEffects()
    {
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.shake, 25, 25));
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.tremble, 100, 100));
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.wave, 50, 25));
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.sad, 3, 3));
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.determ, 25, 0));
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.anxious, 55, 100));
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.relaxed, 15, 5));
        StateNEffects.Add(new EffectTypeAndEffectiveness(TextEffectStates.none, effectScripts.xEffectIntensity,effectScripts.yEffectIntensity));
    }
}
