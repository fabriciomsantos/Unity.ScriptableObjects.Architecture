using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class ConditionBase: ScriptableObject
    {
        public abstract bool Check(StateControllerBase controller);
    }
}
