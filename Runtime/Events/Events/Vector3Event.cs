
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewVector3Event", menuName = "Events/Vector3 Event")]
    public class Vector3Event : BaseGameEvent<Vector3>{} 
}