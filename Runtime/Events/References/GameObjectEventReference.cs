using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class GameObjectEventReference : ScriptableObjectEventReference<GameObject, GameObjectEvent, UnityGameObjectEvent>
    { }
}