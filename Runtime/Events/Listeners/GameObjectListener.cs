﻿using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Listeners
{
    /// <summary>
    /// Add as a Component on an game object
    /// </summary>
    public class GameObjectListener : BaseGameEventListener<GameObject, GameObjectEvent, UnityGameObjectEvent>
    { }
}