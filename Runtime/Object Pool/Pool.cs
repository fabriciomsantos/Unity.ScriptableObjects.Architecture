using System;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.ObjPool
{
    [CreateAssetMenu(fileName = "NewPool", menuName = "Object Pool/Pool")]
    public class Pool : ScriptableObjectsBase
    {
        public Func<Pool, GameObject> EventListener = null;

        [ContextMenu("Spawn on Play")]
        public GameObject Spawn()
        {
            return EventListener(this);
        }
        public GameObject prefab;

        [Min(1)]
        public int size = 1;

        public readonly Queue<GameObject> objectPool = new Queue<GameObject>();


        [Header("Debug on Play")][SerializeField][Tooltip("Editor Only")]
        private bool spawn;

#region Unity Methods

        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        private void OnValidate()
        {
            if (spawn)
            {
                Spawn();
                spawn = false;
            }
        }
#endregion
    }
}