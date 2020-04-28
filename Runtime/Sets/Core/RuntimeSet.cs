using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.RuntimeSet
{
    public abstract class RuntimeSet<T> : ScriptableObjectsBase
    {
        [SerializeField] protected List<T> items = new List<T>();

        public List<T> Items
        {
            get => items;
        }

        public void Add(T thing)
        {
            if (!items.Contains(thing))
            {
                items.Add(thing);
            }
        }

        public void Remove(T thing)
        {
            if (items.Contains(thing))
            {
                items.Remove(thing);
            }
        }
    }
}