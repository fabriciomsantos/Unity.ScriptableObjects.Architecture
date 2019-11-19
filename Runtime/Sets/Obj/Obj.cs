using ScriptableObjectsArchitecture.Inspector;

using UnityEngine;

namespace ScriptableObjectsArchitecture.RuntimeSet
{
    public class Obj : MonoBehaviour
    {
        [InspectInline(canEditRemoteTarget=true)]
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