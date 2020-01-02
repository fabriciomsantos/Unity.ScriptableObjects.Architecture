﻿using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Listeners
{
    /// <summary>
    /// Add as a Component on an game object
    /// </summary>
    public class Vector2Listener : BaseGameEventListener<Vector2, Vector2Event, UnityVector2Event>
    { }
}