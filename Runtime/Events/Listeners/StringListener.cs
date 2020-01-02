﻿using ScriptableObjectsArchitecture.Events.SO;
namespace ScriptableObjectsArchitecture.Events.Listeners
{
    /// <summary>
    /// Add as a Component on an game object
    /// </summary>
    public class StringListener : BaseGameEventListener<string,StringEvent,UnityStringEvent>{}
}