using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class ColorEventReference : ScriptableObjectEventReference<Color, ColorEvent, UnityColorEvent>
    { }
}