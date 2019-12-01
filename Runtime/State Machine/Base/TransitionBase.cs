using System.Collections.Generic;

using ScriptableObjectsArchitecture.Inspector;

using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    [System.Serializable]
    public class TransitionBase
    {
        [Header("Conditions")]
        public List<ConditionBase> conditions = new List<ConditionBase>();

        [InspectInline(canEditRemoteTarget = true)]
        [Header("State")]
        public StateBase state;

        [Header("Debug")][Tooltip("Editor Only")]
        public bool makeTransition;
    }
}