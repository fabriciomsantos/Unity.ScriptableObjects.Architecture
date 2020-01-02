
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewGameObjectEvent", menuName = "Events/GameObject Event")]
    public class GameObjectEvent : BaseGameEvent<GameObject>{} 
}