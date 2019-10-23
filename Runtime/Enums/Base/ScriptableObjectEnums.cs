using UnityEngine;

namespace ScriptableObjectsArchitecture.Enums
{
    //Put in the class that inherits from ScriptableObjectEnums:
    //[CreateAssetMenu(fileName = "NewNameEnum", menuName = "Enums/Name Enum")]

    public abstract class ScriptableObjectEnums : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(5)][SerializeField]
        private string Description;
#endif
    }
}