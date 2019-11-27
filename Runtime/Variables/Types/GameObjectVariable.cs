using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Object
{
    [CreateAssetMenu(fileName = "NewGameObjectVariable", menuName = "Variables/GameObject Variable")]
    public class GameObjectVariable : ScriptableObjectVariable<GameObject>
    {
    }
}
