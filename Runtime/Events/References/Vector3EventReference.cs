﻿using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class Vector3EventReference : ScriptableObjectEventReference<Vector3, Vector3Event, UnityVector3Event>
    { }
}