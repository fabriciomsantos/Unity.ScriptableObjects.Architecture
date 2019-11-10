using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    [System.Serializable]
    public class TransitionBase
    {
        public List<ConditionBase> conditions = new List<ConditionBase>();
        public StateBase state;
    }
}