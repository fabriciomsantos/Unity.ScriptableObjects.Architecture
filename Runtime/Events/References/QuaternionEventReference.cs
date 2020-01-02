using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class QuaternionEventReference : ScriptableObjectEventReference<Quaternion, QuaternionEvent, UnityQuaternionEvent>
    { }
}