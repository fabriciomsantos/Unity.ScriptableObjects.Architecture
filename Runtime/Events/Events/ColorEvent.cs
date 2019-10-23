
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewColorEvent", menuName = "Events/Color Event")]
    public class ColorEvent : BaseGameEvent<Color>{} 
}