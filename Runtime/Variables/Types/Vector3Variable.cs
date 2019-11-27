using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Object
{
    [CreateAssetMenu(fileName = "NewVector3Variable", menuName = "Variables/Vector3 Variable")]
    public class Vector3Variable : ScriptableObjectVariable<Vector3>
    {
        public void AddToValue(Vector3 amount)
        {
            Value += amount;
        }

        public void AddToValue(Vector3Variable amount)
        {
            Value += amount.Value;
        }
    }
}