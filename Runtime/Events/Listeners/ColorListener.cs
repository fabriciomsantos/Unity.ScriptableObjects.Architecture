using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    /// <summary>
    /// Add as a Component on an game object
    /// </summary>
    public class ColorListener : BaseGameEventListener<Color, ColorEvent, UnityColorEvent>
    { }
}