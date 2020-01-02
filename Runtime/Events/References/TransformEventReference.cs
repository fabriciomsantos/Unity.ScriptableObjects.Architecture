using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class TransformEventReference : ScriptableObjectEventReference<Transform, TransformEvent, UnityTransformEvent>
    { }
}