
using System;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events
{
    [Serializable]
    public abstract class BaseGameEvent<T> : ScriptableObject
    {

        /// <summary>
        /// Event keyword makes it so that only this class can trigger the event
        /// Public because anyone can subscribe(+=), and unsubscribe(-=) to/from this event
        /// </summary>
        public event Action<T> EventListeners = delegate
        { };

        public void Raise(T item)
        {
            EventListeners(item);
        }

#if UNITY_EDITOR

        [Multiline(5)][SerializeField]
        private string Description;

        [Header("Debug"),SerializeField,Tooltip("Editor Only")]
        private T valueToTest;

        [SerializeField,Tooltip("Editor Only")]
        private bool raiseOnValueChanged = false;
        
        [SerializeField,Tooltip("Editor Only")]
        private bool raise = false;

        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (raiseOnValueChanged)
                {
                    Raise(valueToTest);
                    raise = false;
                }
                else
                {
                    if (raise)
                    {
                        Raise(valueToTest);
                        raise = false;
                    }
                }
            }
            else
            {
                raise = false;
            }
        }
#endif

    }
}