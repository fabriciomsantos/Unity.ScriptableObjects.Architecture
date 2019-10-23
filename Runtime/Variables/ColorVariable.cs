using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable
{
    [CreateAssetMenu(fileName = "NewColorVariable", menuName = "Variables/Color Variable")]
    public class ColorVariable : ScriptableObjectVariable<Color>
    {
    }
}
