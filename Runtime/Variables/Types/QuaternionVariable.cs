using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.SO
{
    [CreateAssetMenu(fileName = "NewQuaternionVariable", menuName = "Variables/Quaternion Variable")]
    public class QuaternionVariable : ScriptableObjectVariable<Quaternion>
    {
        public void MultiplyValue(Quaternion amount)
        {
            Value *= amount;
        }

        public void MultiplyValue(QuaternionVariable amount)
        {
            Value *= amount.Value;
        }
    }
}