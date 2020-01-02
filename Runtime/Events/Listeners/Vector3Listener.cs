using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    /// <summary>
    /// Add as a Component on an game object
    /// </summary>
    public class Vector3Listener : BaseGameEventListener<Vector3, Vector3Event, UnityVector3Event>
    { }
}