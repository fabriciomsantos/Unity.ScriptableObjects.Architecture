
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewQuaternionEvent", menuName = "Events/Quaternion Event")]
    public class QuaternionEvent : BaseGameEvent<Quaternion>{} 
}