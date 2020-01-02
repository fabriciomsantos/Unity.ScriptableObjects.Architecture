using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class QuaternionEventReference : ScriptableObjectEventReference<Quaternion, QuaternionEvent, UnityQuaternionEvent>
    { }
}