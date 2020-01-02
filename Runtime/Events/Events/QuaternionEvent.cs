
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewQuaternionEvent", menuName = "Events/Quaternion Event")]
    public class QuaternionEvent : BaseGameEvent<Quaternion>{} 
}