using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ScriptableObjectsArchitecture.Events.Reference;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    public abstract class AgentBase : MonoBehaviour
    {
#region Public Variables
        public AgentsRuntime agentsRuntime;
        [Min(0)]
        public float remainingDistanceToDestination = 1.5f;
        public ObjectStates worldState;

#endregion

#region Protected Variables
        [SerializeField]
        protected List<ActionBase> actions = new List<ActionBase>();
        [SerializeField]
        protected List<State> goals = new List<State>();
        [Header("Events")][SerializeField]
        protected VoidEventReference CompleteActionEvent;
        protected Planner planner;
        protected Queue<ActionBase> actionQueue;
        protected ActionBase currentAction;
        protected State currentGoal;
        protected Vector3 destination;
        protected bool invoked;
        protected ObjectStates myState = new ObjectStates();
#endregion

#region Private Variables

#endregion

#region Properties
        public ObjectStates MyState
        {
            get => myState;
        }
        public ActionBase CurrentAction
        {
            get => currentAction;
        }
        public List<State> Goals
        {
            get => goals;
        }
        public List<ActionBase> Actions
        {
            get => actions;
        }
        public Queue<ActionBase> ActionQueue
        {
            get => actionQueue;
        }
#endregion

#region Unity Methods

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        public virtual void Awake()
        {
            actions.AddRange(GetComponentsInChildren<ActionBase>());
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        public virtual void OnEnable()
        {
            agentsRuntime.Add(this);
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        public virtual void OnDisable()
        {
            agentsRuntime.Remove(this);
        }

        /// <summary>
        /// LateUpdate is called every frame, if the Behaviour is enabled.
        /// It is called after all Update functions have been called.
        /// </summary>
        public virtual void LateUpdate()
        {
            if (currentAction?.executing == true)
            {
                if (currentAction.target && DistanceToTarget(destination, transform.position) < remainingDistanceToDestination && !invoked)
                {
                    Invoke(nameof(CompleteAction), currentAction.duration);
                    invoked = true;
                }
                else if (!currentAction.target && !invoked)
                {
                    Invoke(nameof(CompleteAction), currentAction.duration);
                    invoked = true;
                }
                return;
            }

            if (planner == null || actionQueue == null)
            {
                planner = new Planner();
                var sortedGoals = goals.OrderByDescending(x => x.Priority).ToList();

                foreach (var sortedGoal in sortedGoals)
                {
                    actionQueue = planner.Plan(actions, sortedGoals, worldState, MyState);
                    if (actionQueue != null)
                    {
                        currentGoal = sortedGoal;
                        break;
                    }
                }
            }

            if (actionQueue?.Count == 0)
            {
                if (!currentGoal.Permanent)
                {
                    currentGoal.Value--;
                    if (currentGoal.Value <= 0)
                    {
                        goals.Remove(currentGoal);
                    }
                }
                planner = null;
            }

            if (actionQueue?.Count > 0)
            {
                currentAction = actionQueue.Dequeue();
                if (currentAction.PrePerform())
                {
                    currentAction.executing = true;

                    destination = currentAction.target.transform.position;

                    SetDestination(destination);
                }
                else
                {
                    actionQueue = null;
                }
            }
        }

#endregion

#region Public Methods

        public abstract void SetDestination(Vector3 destination);

        public virtual float DistanceToTarget(Vector3 position1, Vector3 position2)
        {
            return Vector3.Distance(position1, position2);
        }

        public virtual void CompleteAction()
        {
            currentAction.executing = false;
            CompleteActionEvent.Raise();
            currentAction.PostPerform();
            invoked = false;
        }
#endregion

#region Private Methods

#endregion
    }
}