using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.ObjPool
{
    public class ObjectPool : MonoBehaviour
    {
#region Public Variables
        public List<Pool> pools;

#endregion

#region Private Variables

#endregion

#region Unity Methods

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            InitializePool();
        }
#endregion

#region Public Methods

#endregion

#region Private Methods
        /// <summary>
        /// Assing list to the dictionary
        /// </summary>
        private void InitializePool()
        {
            foreach (var pool in pools)
            {
                pool.EventListener = SpawnFromPool;
                if (pool.prefab)
                {
                    for (int i = 0; i < pool.size; i++)
                    {
                        GameObject obj = Instantiate(pool.prefab);
                        obj.SetActive(false);
                        pool.objectPool.Enqueue(obj);
                    }
                }
                else
                {
                    Debug.LogWarning("Pool with name " + pool + " doesn't have a prefab");
                }
            }
        }

        /// <summary>
        /// Spawn object from the pool
        /// </summary>
        /// <param name="pool"></param>
        /// <returns>return spawn object</returns>
        private GameObject SpawnFromPool(Pool pool)
        {
            if (!pool)
            {
                Debug.LogWarning(pool + " doesn't exist");
                return null;
            }
            if (pool.objectPool.Count == 0)
            {
                Debug.LogWarning(pool + " is empty");
                return null;
            }

            GameObject objectToSpawn = pool.objectPool.Dequeue();

            objectToSpawn.SetActive(true);

            pool.objectPool.Enqueue(objectToSpawn);

            return objectToSpawn;
        }

#endregion     
    }
}