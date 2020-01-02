
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewFloatEvent", menuName = "Events/Float Event")]
    public class FloatEvent : BaseGameEvent<float>{} 
}