using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract  class ActionBase : ScriptableObject 
    {
        public abstract void Act(StateControllerBase controller);
    }
}
