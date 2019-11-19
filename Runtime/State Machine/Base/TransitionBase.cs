using System.Collections.Generic;


namespace ScriptableObjectsArchitecture.StateMachine
{
    [System.Serializable]
    public class TransitionBase
    {
        public List<ConditionBase> conditions = new List<ConditionBase>();

        #if UNITY_EDITOR 
        [Inspector.InspectInline(canEditRemoteTarget =true)]
        #endif
        public StateBase state;
    }
}