using UnityEngine;

namespace ScriptableObjectsArchitecture.Enums
{
    //Put in the class that inherits from ScriptableObjectEnums:
    //[CreateAssetMenu(fileName = "NewNameEnum", menuName = "Enums/Name Enum")]

    public abstract class ScriptableObjectEnums : ScriptableObject
    {
        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;
    }
}