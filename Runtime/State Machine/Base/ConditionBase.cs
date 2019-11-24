using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class ConditionBase : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;
#endif
        public abstract bool Check(StateMachineControllerBase controller);
    }
}