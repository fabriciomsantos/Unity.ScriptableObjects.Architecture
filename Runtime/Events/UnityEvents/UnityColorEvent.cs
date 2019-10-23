using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsArchitecture.Events
{
    [System.Serializable]
    public class UnityColorEvent : UnityEvent<Color>
    { }
}