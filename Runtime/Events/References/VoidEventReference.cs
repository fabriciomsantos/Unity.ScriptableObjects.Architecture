﻿using ScriptableObjectsArchitecture.Events.SO;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class VoidEventReference : ScriptableObjectEventReference<Void, VoidEvent, UnityVoidEvent>
    {
        public void Raise()
        {
            gameEvent?.Raise();
            unityEvent.Invoke(null);
        }
    }
}