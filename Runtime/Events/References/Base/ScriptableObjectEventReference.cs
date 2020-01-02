using System.Collections;
using System.Collections.Generic;

using ScriptableObjectsArchitecture.Inspector;

using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    public abstract class ScriptableObjectEventReference<T, GE, UE> where GE : BaseGameEvent<T> where UE : UnityEvent<T>, new()
    {
#pragma warning disable 0649
        [InspectInline(canEditRemoteTarget = true)]
        public GE gameEvent;
#pragma warning restore 0649

        public UE unityEvent = new UE();

        public void Raise(T item)
        {
            gameEvent?.Raise(item);
            unityEvent.Invoke(item);
        }
    }
}