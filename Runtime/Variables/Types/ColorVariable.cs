using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.SO
{
    [CreateAssetMenu(fileName = "NewColorVariable", menuName = "Variables/Color Variable")]
    public class ColorVariable : ScriptableObjectVariable<Color>
    {
    }
}
