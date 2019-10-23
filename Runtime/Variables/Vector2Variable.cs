using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable
{
    [CreateAssetMenu(fileName = "NewVector2Variable", menuName = "Variables/Vector2 Variable")]
    public class Vector2Variable :  ScriptableObjectVariable<Vector2>
    {
        public void AddToValue(Vector2 amount)
        {
            Value += amount;
        }

        public void AddToValue(Vector2Variable amount)
        {
            Value += amount.Value;
        }
    }
}
