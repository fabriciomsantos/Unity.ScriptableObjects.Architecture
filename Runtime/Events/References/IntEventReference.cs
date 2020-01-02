using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class IntEventReference : ScriptableObjectEventReference<int, IntEvent, UnityIntEvent>
    { }
}