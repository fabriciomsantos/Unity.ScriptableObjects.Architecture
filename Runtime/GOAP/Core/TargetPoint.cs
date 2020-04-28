using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    public class TargetPoint : MonoBehaviour
    {
#region Public Variables
        public TargetType targetType;
#endregion

#region Protected Variables

#endregion

#region Private Variables

#endregion

#region Properties

#endregion

#region Unity Methods

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        void OnEnable()
        {
            targetType?.AddResource(gameObject);
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        void OnDisable()
        {
            targetType?.RemoveResource(gameObject);
        }
#endregion

#region Public Methods

#endregion

#region Protected Methods

#endregion

#region Private Methods

#endregion
    }
}