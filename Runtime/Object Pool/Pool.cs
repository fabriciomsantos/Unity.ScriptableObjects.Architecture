using System;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.ObjPool
{
    [CreateAssetMenu(fileName = "NewPool", menuName = "Object Pool/Pool")]
    public class Pool : ScriptableObject
    {
        public Func<Pool, GameObject> EventListener = null;
        public GameObject Spawn()
        {
            return EventListener(this);
        }
        public GameObject prefab;

        [Min(1)]
        public int size = 1;

        public readonly Queue<GameObject> objectPool = new Queue<GameObject>();
    }
}