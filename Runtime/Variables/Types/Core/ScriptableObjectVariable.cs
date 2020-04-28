

namespace ScriptableObjectsArchitecture.Variable.SO
{
    public abstract class ScriptableObjectVariable<T> : ScriptableObjectsBase
    {
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