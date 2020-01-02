
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewVector2Event", menuName = "Events/Vector2 Event")]
    public class Vector2Event : BaseGameEvent<Vector2>{} 
}