using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsArchitecture.Events
{
    [System.Serializable]
    public class UnityGameObjectEvent : UnityEvent<GameObject>
    { }
}