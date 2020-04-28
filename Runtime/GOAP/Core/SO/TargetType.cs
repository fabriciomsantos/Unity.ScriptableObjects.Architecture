using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
namespace ScriptableObjectsArchitecture.GOAP
{
    [CreateAssetMenu(fileName = "NewTargetType", menuName = "GOAP/Target Type")]
    public class TargetType : ScriptableObjectsBase
    {
        public enum AmountType
        {
            Limited,
            Unlimited,
            Unique
        }
#region Public Variables

#endregion

#region Protected Variables

#endregion

#region Private Variables

        [SerializeField]
        private AmountType amount;
        protected Queue<GameObject> queue = new Queue<GameObject>();

#endregion

#region Properties
        public Queue<GameObject> Queue
        {
            get => queue;
        }
        public AmountType Amount
        {
            get => amount;
            set => amount = value;
        }
#endregion

#region Public Methods

        public GameObject UseResource()
        {
            GameObject resource = RemoveResource();
            switch (amount)
            {
                case AmountType.Limited:
                    break;
                case AmountType.Unlimited:
                    AddResource(resource);
                    break;
                case AmountType.Unique:
                    break;
            }
            return resource;
        }

        public void FinishedResourceUsage(GameObject resource)
        {
            switch (amount)
            {
                case AmountType.Limited:
                    AddResource(resource);
                    break;
                case AmountType.Unlimited:
                    break;
                case AmountType.Unique:
                    break;
            }
        }

        public void AddResource(GameObject resource)
        {
            Queue.Enqueue(resource);
        }

        public void RemoveResource(GameObject resource)
        {
            queue = new Queue<GameObject>(queue.Where(go => go != resource));
        }

        public GameObject RemoveResource()
        {
            if (Queue.Count == 0)
            {
                return null;
            }
            else
            {
                return Queue.Dequeue();
            }
        }

#endregion

#region Private Methods

#endregion
    }
}