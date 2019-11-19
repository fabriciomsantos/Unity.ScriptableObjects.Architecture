using UnityEngine;

namespace ScriptableObjectsArchitecture.RuntimeSet
{
    public class Obj : MonoBehaviour
    {
        #if UNITY_EDITOR 
        [Inspector.InspectInline(canEditRemoteTarget =true)]
        #endif
        public ObjRuntimeSet RuntimeSet;

        private void OnEnable()
        {
            RuntimeSet.Add(this);
        }

        private void OnDisable()
        {
            RuntimeSet.Remove(this);
        }
    }
}