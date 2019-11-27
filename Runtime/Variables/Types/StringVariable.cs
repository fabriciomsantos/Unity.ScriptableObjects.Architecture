using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Object
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "Variables/String Variable")]
    public class StringVariable : ScriptableObjectVariable<string>
    {
    }
}
