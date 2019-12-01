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
                SaveGame();
                save = false;
            }

            if (load)
            {
                LoadGame();
                load = false;
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
        public void SaveGame()
        {
            foreach (var save in saveFiles)
            {
                var filePath = Path.Combine(Application.persistentDataPath, save.fileName);
                string dataAsJson = "";
                foreach (var objectToSave in save.objectsToSave)
                {
                    if (objectToSave)
                    {
                        dataAsJson += JsonUtility.ToJson(objectToSave, save.formatJson) + separator + "\n";
                    }
                    else
                    {
                        Debug.LogError("missing object data");
                    }
                }

                if (dataAsJson?.Length > 0)
                {
                    if (save.useEncryption)
                    {
                        dataAsJson = AesOperationEncryption.EncryptString(save.encryptionKey, dataAsJson);
                        dataAsJson = BinaryString.StringToBinary(dataAsJson);
                    }
                    File.WriteAllText(filePath, dataAsJson);
                    Debug.Log("File Saved");
                }
            }
        }

        public void LoadGame()
        {
            foreach (var save in saveFiles)
            {
                if (save.fileName?.Length == 0)
                {
                    Debug.LogWarning("Enter file name");
                    return;
                }

                var filePath = Path.Combine(Application.persistentDataPath, save.fileName);

                if (File.Exists(filePath))
                {
                    string dataAsJson = File.ReadAllText(filePath);

                    if (save.useEncryption)
                    {
                        dataAsJson = BinaryString.BinaryToString(dataAsJson);
                        dataAsJson = AesOperationEncryption.DecryptString(save.encryptionKey, dataAsJson);
                    }

                    for (int i = 0; i < save.objectsToSave.Length; i++)
                    {
                        string[] types = dataAsJson.Split(separator);
                        JsonUtility.FromJsonOverwrite(types[i], save.objectsToSave[i]);
                        Debug.Log("File Loaded");
                    }
                }
                else
                {
                    Debug.LogError("Couldn't find save file");
                }
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