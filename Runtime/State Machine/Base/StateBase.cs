using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class StateBase : ScriptableObject
    {
        #region Public Variables
        public List<ActionBase> actions;
        public List<TransitionBase> transitions;

        #endregion

        #region Private Variables

        #endregion

        #region Unity Methods

        #endregion

        #region Public Methods
        public abstract void EnterState(StateControllerBase controller);

        public void UpdateState(StateControllerBase controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        public abstract void ExitState(StateControllerBase controller);

        #endregion

        #region Private Methods
        private void DoActions(StateControllerBase controller)
        {
            foreach (var action in actions)
            {
                action.Act(controller);
            }
        }

        private void CheckTransitions(StateControllerBase controller)
        {
            foreach (var transition in transitions)
            {
                var conditionsSucceeded = true;
                foreach (var condition in transition.conditions)
                {
                    conditionsSucceeded = condition.Check(controller);
                }

                if (conditionsSucceeded)
                {
                    ExitState(controller);
                    controller.TransitionToState(this);
                }
            }
        }

        #endregion
    }
}