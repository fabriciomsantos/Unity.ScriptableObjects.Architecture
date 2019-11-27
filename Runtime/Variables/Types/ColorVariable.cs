using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Object
{
    [CreateAssetMenu(fileName = "NewColorVariable", menuName = "Variables/Color Variable")]
    public class ColorVariable : ScriptableObjectVariable<Color>
    {
    }
}
