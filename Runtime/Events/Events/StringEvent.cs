
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewStringEvent", menuName = "Events/String Event")]
    public class StringEvent : BaseGameEvent<string>{} 
}