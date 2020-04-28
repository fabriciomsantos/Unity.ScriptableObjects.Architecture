using UnityEngine;

namespace ScriptableObjectsArchitecture
{
    public abstract class ScriptableObjectsBase : ScriptableObject
    {
        [Multiline(8)][SerializeField][Tooltip("Editor Only")]
        private string description;
    }
}