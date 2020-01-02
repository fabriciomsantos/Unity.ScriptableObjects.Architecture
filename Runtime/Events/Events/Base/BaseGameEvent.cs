using System;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
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

        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;

#pragma warning disable CS0649
        [Header("Debug"), SerializeField, Tooltip("Editor Only")]
        private T valueToTest;
#pragma warning restore CS0649

        [SerializeField, Tooltip("Editor Only")]
        private bool raiseOnValueChanged = false;

        [SerializeField, Tooltip("Editor Only")]
        private bool raise;

        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (raiseOnValueChanged)
                {
                    Raise(valueToTest);
                    raise = false;
                }
                else if (raise)
                {
                    Raise(valueToTest);
                    raise = false;
                }
            }
            else
            {
                raise = false;
            }
        }

    }
}