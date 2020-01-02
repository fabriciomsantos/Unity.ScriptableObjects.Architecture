using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.SO
{
    [CreateAssetMenu(fileName = "NewTransformVariable", menuName = "Variables/Transform Variable")]
    public class TransformVariable : ScriptableObjectVariable<Transform>
    {
    }
}
