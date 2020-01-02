using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.SO
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "Variables/Int Variable")]
    public class IntVariable : ScriptableObjectVariable<int>
    {
        public void AddToValue(int amount)
        {
            Value += amount;
        }

        public void AddToValue(IntVariable amount)
        {
            Value += amount.Value;
        }
    }
}