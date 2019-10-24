﻿using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    /// <summary>
    /// Add as a Component on an game object
    /// </summary>
    public class TransformListener : BaseGameEventListener<Transform, TransformEvent, UnityTransformEvent>
    { }
}