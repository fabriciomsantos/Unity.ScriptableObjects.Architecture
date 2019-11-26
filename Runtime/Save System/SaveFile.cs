using UnityEngine;

namespace ScriptableObjectsArchitecture.Save
{
    [CreateAssetMenu(fileName = "NewSaveFile", menuName = "Save System/Save File")]
    public class SaveFile : ScriptableObject
    {
        [Header("Settings")][Tooltip("fileName.Extention")]
        public string fileName;

        public bool formatJson;

        [Header("Encryption")]
        public bool useEncryption;

        public string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";

        [Header("Objects")]
        public ScriptableObject[] objectsToSave;
    }
}