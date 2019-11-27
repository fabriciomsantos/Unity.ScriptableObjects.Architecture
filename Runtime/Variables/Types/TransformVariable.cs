using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Object
{
    [CreateAssetMenu(fileName = "NewTransformVariable", menuName = "Variables/Transform Variable")]
    public class TransformVariable : ScriptableObjectVariable<Transform>
    {
    }
}
