using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.SO
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "Variables/String Variable")]
    public class StringVariable : ScriptableObjectVariable<string>
    {
    }
}
