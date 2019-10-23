
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewIntEvent", menuName = "Events/Int Event")]
    public class IntEvent : BaseGameEvent<int>{} 
}