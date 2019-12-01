﻿using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.RuntimeSet
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;

        public List<T> Items = new List<T>();

        public void Add(T thing)
        {
            if (!Items.Contains(thing))
            {
                Items.Add(thing);
            }
        }

        public void Remove(T thing)
        {
            if (Items.Contains(thing))
            {
                Items.Remove(thing);
            }
        }
    }
}