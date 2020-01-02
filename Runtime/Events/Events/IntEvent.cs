
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewIntEvent", menuName = "Events/Int Event")]
    public class IntEvent : BaseGameEvent<int>{} 
}