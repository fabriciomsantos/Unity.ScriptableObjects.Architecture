using ScriptableObjectsArchitecture.Events.SO;
namespace ScriptableObjectsArchitecture.Events.Listeners
{
    /// <summary>
    /// Add as a Component on an game object
    /// </summary>
    public class BoolListener : BaseGameEventListener<bool, BoolEvent, UnityBoolEvent>
    { }
}