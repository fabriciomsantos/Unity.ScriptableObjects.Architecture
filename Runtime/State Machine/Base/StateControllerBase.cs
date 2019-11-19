﻿using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class StateControllerBase : MonoBehaviour
    {
        #region Public Variables

        #if UNITY_EDITOR 
        [Inspector.InspectInline(canEditRemoteTarget =true)]
        #endif
        public StateBase currentState;

        #endregion

        #region Private Variables

        #endregion

        #region Unity Methods

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        public virtual void Update()
        {
            currentState?.UpdateState(this);
        }

        #endregion

        #region Public Methods
        public void TransitionToState(StateBase nextState)
        {
            currentState = nextState;
            currentState?.EnterState(this);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}