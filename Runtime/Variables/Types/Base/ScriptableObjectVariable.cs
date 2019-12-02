using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Object
{
    public abstract class ScriptableObjectVariable<T> : ScriptableObject
    {
        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;

        public T Value;

        public void SetValue(T value)
        {
            Value = value;
        }

        public void SetValue(ScriptableObjectVariable<T> value)
        {
            Value = value.Value;
        }

        public static implicit operator T(ScriptableObjectVariable<T> reference)
        {
            return reference.Value;
        }
    }
}