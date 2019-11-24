using ScriptableObjectsArchitecture.Inspector;

using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class StateMachineControllerBase : MonoBehaviour
    {
        #region Public Variables

        [InspectInline(canEditRemoteTarget = true)]
        public StateBase currentState;

        #endregion

        #region Private Variables

        #endregion

        #region Unity Methods
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        public virtual void Start()
        {
            currentState?.EnterState(this);
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        public virtual void Update()
        {
            currentState?.UpdateState();
        }

        #endregion

        #region Public Methods
        public void TransitionToState(StateBase nextState)
        {
            currentState?.ExitState(this);
            currentState = nextState;
            currentState?.EnterState(this);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}