using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    public class Inventory : MonoBehaviour
    {
#region Public Variables
        public List<GameObject> items = new List<GameObject>();

#endregion

#region Protected Variables

#endregion

#region Private Variables

#endregion

#region Properties

#endregion

#region Public Methods
        public void AddItem(GameObject item)
        {
            items.Add(item);
        }
        public GameObject FindItemWithTag(string tag)
        {
            foreach (var item in items)
            {
                if (item && item.tag.Equals(tag))
                {
                    return item;
                }
            }
            return null;
        }
        public bool RemoveItem(GameObject item)
        {
            return items.Remove(item);
        }

#endregion

#region Private Methods

#endregion
    }
}