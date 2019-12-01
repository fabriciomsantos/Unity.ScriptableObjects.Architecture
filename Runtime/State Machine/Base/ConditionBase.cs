using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class ConditionBase : ScriptableObject
    {
        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;
        public abstract bool Check(StateMachineControllerBase controller);
    }
}