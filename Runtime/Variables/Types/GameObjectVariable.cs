using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.SO
{
    [CreateAssetMenu(fileName = "NewGameObjectVariable", menuName = "Variables/GameObject Variable")]
    public class GameObjectVariable : ScriptableObjectVariable<GameObject>
    {
    }
}
