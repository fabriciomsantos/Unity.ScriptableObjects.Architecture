using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    [CreateAssetMenu(fileName = "NewState", menuName = "GOAP/State")]
    public class State : ScriptableObjectsBase
    {
#region Public Variables

#endregion

#region Protected Variables

#endregion

#region Private Variables
        [SerializeField][Min(0)]
        private int value = 1;
        [SerializeField]
        private int priority;

        [SerializeField]
        private bool permanent;

#endregion

#region Properties
        public int Priority
        {
            get => priority;
            set => priority = value;
        }
        public int Value
        {
            get => value;
            set => this.value = value;
        }
        public bool Permanent
        {
            get => permanent;
            set => permanent = value;
        }

#endregion

#region Public Methods

        public void ModifyValue(int modifier)
        {
            value = Mathf.Max(0, value + modifier);
        }
        public void ModifyPriority(int modifier)
        {
            priority = Mathf.Max(0, priority + modifier);
        }

#endregion

#region Private Methods

#endregion
    }
}