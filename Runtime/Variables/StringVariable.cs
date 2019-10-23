using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "Variables/String Variable")]
    public class StringVariable : ScriptableObjectVariable<string>
    {
    }
}
