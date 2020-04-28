using System.Collections;
using System.Collections.Generic;

using ScriptableObjectsArchitecture.Inspector;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    public class GOAPManager : MonoBehaviour
    {
#region Public Variables
        [InspectInline(canEditRemoteTarget = true)]
        public AgentsRuntime agents;
        public List<TargetType> targetTypes = new List<TargetType>();

#endregion

#region Protected Variables

#endregion

#region Private Variables
        protected ObjectStates worldStates = new ObjectStates();
#endregion

#region Properties
        public ObjectStates WorldStates
        {
            get => worldStates;
        }
#endregion

#region Unity Methods
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        { }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            foreach (var agent in agents.Items)
            {
                agent.worldState = WorldStates;
            }
        }
    }

#endregion

#region Public Methods

#endregion

#region Private Methods

#endregion
}