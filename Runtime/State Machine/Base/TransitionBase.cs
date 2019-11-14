using System.Collections.Generic;

using ScriptableObjectsArchitecture.Inspector;

namespace ScriptableObjectsArchitecture.StateMachine
{
    [System.Serializable]
    public class TransitionBase
    {
        public List<ConditionBase> conditions = new List<ConditionBase>();

        [InspectInline(canEditRemoteTarget=true)]
        public StateBase state;
    }
}