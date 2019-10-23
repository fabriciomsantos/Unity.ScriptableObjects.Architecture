using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable
{
    [CreateAssetMenu(fileName = "NewTransformVariable", menuName = "Variables/Transform Variable")]
    public class TransformVariable : ScriptableObjectVariable<Transform>
    {
    }
}
