using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsArchitecture.Events
{
    [System.Serializable]
    public class UnityVector3Event : UnityEvent<Vector3>
    { }
}