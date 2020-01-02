
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewTransformEvent", menuName = "Events/Transform Event")]
    public class TransformEvent : BaseGameEvent<Transform>{} 
}