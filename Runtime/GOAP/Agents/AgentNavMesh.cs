using UnityEngine;
using UnityEngine.AI;

namespace ScriptableObjectsArchitecture.GOAP
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class AgentNavMesh : AgentBase
    {
#region Public Variables
        [HideInInspector]
        public NavMeshAgent navMeshAgent;

#endregion

#region Private Variables

#endregion

#region Unity Methods
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        public override void Awake()
        {
            base.Awake();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

#endregion

#region Public Methods
        // public override float DistanceToTarget(Vector3 position1, Vector3 position2)
        // {
        //     return navMeshAgent.remainingDistance;
        // }
        public override void SetDestination(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
        }

#endregion

#region Private Methods

#endregion
    }
}