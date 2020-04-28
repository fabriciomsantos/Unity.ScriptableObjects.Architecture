using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Save
{
    public class LocalSaveManager : MonoBehaviour
    {
#region Public Variables
        [Header("Settings")]
        public bool loadOnEnable;

        [Header("Objects")]
        public SaveFile[] saveFiles;

#endregion

#region Private Variables
        private const char separator = ';';

        [Header("Debug")][SerializeField][Tooltip("Editor Only")]
        private bool loadAll;

        [SerializeField][Tooltip("Editor Only")]
        private bool saveAll;

#endregion

#region Unity Methods

        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        private void OnValidate()
        {
            if (saveAll)
            {
                SaveGame();
                saveAll = false;
            }

            if (loadAll)
            {
                LoadGame();
                loadAll = false;
            }
        }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            foreach (var file in saveFiles)
            {
                file.SaveEvent += SaveFile;
                file.LoadEvent += LoadFile;
            }
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            if (loadOnEnable)
            {
                LoadGame();
            }
        }

#endregion

#region Public Methods

        [ContextMenu("Save All Files")]
        public void SaveGame()
        {
            foreach (var file in saveFiles)
            {
                SaveFile(file);
            }
        }

        public void SaveFile(SaveFile file)
        {
            if (file.fileName?.Length == 0)
            {
                Debug.LogWarning("Enter file name");
                return;
            }

            string dataAsJson = "";
            foreach (var objectToSave in file.objectsToSave)
            {
                if (objectToSave)
                {
                    dataAsJson += JsonUtility.ToJson(objectToSave, file.formatJson) + separator + "\n";
                }
                else
                {
                    Debug.LogError("missing object data");
                }
            }

            if (dataAsJson?.Length > 0)
            {
                if (file.useEncryption)
                {
                    dataAsJson = AesOperationEncryption.EncryptString(file.encryptionKey, dataAsJson);
                    dataAsJson = BinaryString.StringToBinary(dataAsJson);
                }

                switch (file.saveLocation)
                {
                    case SaveLocation.LocalFile:
                        var filePath = Path.Combine(Application.persistentDataPath, file.fileName);
                        File.WriteAllText(filePath, dataAsJson);
                        break;

                    case SaveLocation.PlayerPref:
                        PlayerPrefs.SetString(file.fileName, dataAsJson);
                        break;
                }

                Debug.Log(file.fileName + " Saved");
            }
        }

        [ContextMenu("Load All Files")]
        public void LoadGame()
        {
            foreach (var file in saveFiles)
            {
                LoadFile(file);
            }
        }

        public void LoadFile(SaveFile file)
        {
            if (file.fileName?.Length == 0)
            {
                Debug.LogWarning("Enter file name");
                return;
            }

            string dataAsJson = "";

            switch (file.saveLocation)
            {
                case SaveLocation.LocalFile:
                    var filePath = Path.Combine(Application.persistentDataPath, file.fileName);

                    if (File.Exists(filePath))
                    {
                        dataAsJson = File.ReadAllText(filePath);
                    }
                    break;

                case SaveLocation.PlayerPref:
                    dataAsJson = PlayerPrefs.GetString(file.fileName);
                    break;
            }

            if (dataAsJson?.Length > 0)
            {
                if (file.useEncryption)
                {
                    dataAsJson = BinaryString.BinaryToString(dataAsJson);
                    dataAsJson = AesOperationEncryption.DecryptString(file.encryptionKey, dataAsJson);
                }

                for (int i = 0; i < file.objectsToSave.Length; i++)
                {
                    string[] types = dataAsJson.Split(separator);
                    JsonUtility.FromJsonOverwrite(types[i], file.objectsToSave[i]);
                    Debug.Log(file.fileName + " Loaded");
                }
            }
            else
            {
                Debug.LogError("Couldn't find save file");
            }
        }

#endregion

#region Private Methods

#endregion
    }

    public static class BinaryString
    {
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data)
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinaryToString(string data)
        {
            var byteList = new List<byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }

    public static class AesOperationEncryption
    {
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using(Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using(MemoryStream memoryStream = new MemoryStream())
                {
                    using(CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using(Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using(MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using(CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using(StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}