using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class ActionBase : ScriptableObject
    {
        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;
        public abstract void Execute(StateMachineControllerBase controller);
    }
}