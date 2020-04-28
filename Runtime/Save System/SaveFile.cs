using System;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Save
{
    [CreateAssetMenu(fileName = "NewSaveFile", menuName = "Save System/Save File")]
    public class SaveFile : ScriptableObjectsBase
    {
#region Public Variables
        public Action<SaveFile> SaveEvent = null;
        public Action<SaveFile> LoadEvent = null;

        [Header("Settings")][Tooltip("fileName.Extention")]
        public string fileName;

        public bool formatJson;

        public SaveLocation saveLocation;
        [Header("Encryption")]
        public bool useEncryption;

        public string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";

        [Header("Objects")]
        public ScriptableObject[] objectsToSave;

#endregion

#region Private Variables

        [Header("Debug on Play")][SerializeField][Tooltip("Editor Only")]
        private bool load;

        [SerializeField][Tooltip("Editor Only")]
        private bool save;

#endregion

#region Unity Methods

        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        private void OnValidate()
        {
            if (save)
            {
                Save();
                save = false;
            }

            if (load)
            {
                Load();
                load = false;
            }
        }

#endregion

#region Public Methods
        [ContextMenu("Save on Play")]
        public void Save()
        {
            SaveEvent(this);
        }

        [ContextMenu("Load on Play")]
        public void Load()
        {
            LoadEvent(this);
        }

#endregion

    }

    public enum SaveLocation
    {
        LocalFile,
        PlayerPref
    }
}