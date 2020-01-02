using ScriptableObjectsArchitecture.Inspector;
using ScriptableObjectsArchitecture.Variable.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Reference
{
    public class ScriptableObjectVariableReference<T, U> where U : ScriptableObjectVariable<T>
    {
#pragma warning disable 0649

        [SerializeField]
        private T InspectorValue;

        [SerializeField][InspectInline(canEditRemoteTarget = true)]
        private U Variable;

#pragma warning restore 0649
        public ScriptableObjectVariableReference()
        { }

        public ScriptableObjectVariableReference(T value)
        {
            if (Variable != null)
            {
                Variable.Value = value;
                InspectorValue = value;
            }
            else
            {
                InspectorValue = value;
            }
        }

        public T Value
        {
            set
            {
                if (Variable != null)
                {
                    Variable.Value = value;
                    InspectorValue = value;
                }
                else
                {
                    InspectorValue = value;
                }
            }
            get
            {
                if (Variable != null)
                {
                    return Variable.Value;
                }
                else
                {
                    return InspectorValue;
                }
            }
        }

        public static implicit operator T(ScriptableObjectVariableReference<T, U> reference)
        {
            return reference.Value;
        }
    }
}