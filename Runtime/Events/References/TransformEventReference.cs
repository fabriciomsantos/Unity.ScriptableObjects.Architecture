using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class TransformEventReference : ScriptableObjectEventReference<Transform, TransformEvent, UnityTransformEvent>
    { }
}