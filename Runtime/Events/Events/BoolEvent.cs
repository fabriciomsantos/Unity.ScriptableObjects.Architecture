﻿
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewBoolEvent", menuName = "Events/Bool Event")]
    public class BoolEvent : BaseGameEvent<bool>{} 
}