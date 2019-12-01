using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.StateMachine
{
    public abstract class StateBase : ScriptableObject
    {
        #region Public Variables
        [Multiline(5)][SerializeField][Tooltip("Editor Only")]
        private string description;

        [Header("Actions")]
        public List<ActionBase> onEnterActions;

        public List<ActionBase> onUpdateActions;
        public List<ActionBase> onExitActions;

        [Header("Transitions")]
        public List<TransitionBase> transitions;

        #endregion

        #region Private Variables
        private StateMachineControllerBase controller;

        #endregion

        #region Unity Methods


        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        private void OnValidate()
        {
            foreach (var transition in transitions)
            {
                if (Application.isPlaying)
                {
                    if (transition.makeTransition && transition.state)
                    {
                        controller?.TransitionToState(transition.state);
                        transition.makeTransition = false;
                    }
                }
                else
                {
                    transition.makeTransition = false;
                }
            }
        }

        #endregion

        #region Public Methods
        public void EnterState(StateMachineControllerBase _controller)
        {
            controller = _controller;
            ExecuteOnEnterActions();
        }

        public void UpdateState()
        {
            ExecuteOnUpdateActions();
            CheckTransitions();
        }

        public void ExitState(StateMachineControllerBase _controller)
        {
            controller = _controller;
            ExecuteOnExitActions();
        }

        #endregion

        #region Private Methods
        private void ExecuteOnEnterActions()
        {
            foreach (var onEnterAction in onEnterActions)
            {
                onEnterAction?.Execute(controller);
            }
        }

        private void ExecuteOnUpdateActions()
        {
            foreach (var onUpdateAction in onUpdateActions)
            {
                onUpdateAction?.Execute(controller);
            }
        }

        private void ExecuteOnExitActions()
        {
            foreach (var onExitAction in onExitActions)
            {
                onExitAction?.Execute(controller);
            }
        }

        private void CheckTransitions()
        {
            foreach (var transition in transitions)
            {
                var conditionsSucceeded = true;
                foreach (var condition in transition.conditions)
                {
                    if (condition)
                    {
                        conditionsSucceeded = condition.Check(controller);
                    }
                }

                if (conditionsSucceeded && transition.state)
                {
                    controller?.TransitionToState(transition.state);
                }
            }
        }

        #endregion
    }
}