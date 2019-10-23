using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Variables/Float Variable")]
    public class FloatVariable : ScriptableObjectVariable<float>
    {
        public void AddToValue(float amount)
        {
            Value += amount;
        }

        public void AddToValue(FloatVariable amount)
        {
            Value += amount.Value;
        }
    }
}