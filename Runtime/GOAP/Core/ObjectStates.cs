using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    public class ObjectStates
    {
#region Public Variables

#endregion

#region Protected Variables
        protected List<State> states = new List<State>();
#endregion

#region Private Variables

#endregion

#region Properties
        public List<State> States
        {
            get => states;
        }

#endregion

#region Public Methods
        public bool HasState(State state)
        {
            return states.Contains(state);
        }

        public bool HasState(string stateName)
        {
            return states.Find(x => x.name.Equals(stateName));
        }

        public void SetState(State oldState, State newState)
        {
            if (HasState(oldState))
            {
                states[FindStateIndex(oldState)] = newState;
            }
            else
            {
                states.Add(newState);
            }
        }

        public void SetState(string oldStateName, State newState)
        {
            if (HasState(oldStateName))
            {
                states[FindStateIndex(oldStateName)] = newState;
            }
            else
            {
                states.Add(newState);
            }
        }

        public State GetState(State state)
        {
            return states.Find(x => x.Equals(state));
        }

        public State GetState(string stateName)
        {
            return states.Find(x => x.name.Equals(stateName));
        }

        public int FindStateIndex(State state)
        {
            return states.FindIndex(x => x.Equals(state));
        }

        public int FindStateIndex(string stateName)
        {
            return states.FindIndex(x => x.name.Equals(stateName));
        }

        public void AddState(State state)
        {
            states.Add(state);
        }

        public void ModifyStateValue(State state, int value)
        {
            if (HasState(state))
            {
                GetState(state).Value += value;
                if (GetState(state).Value <= 0)
                {
                    RemoveState(state);
                }
            }
            else
            {
                if (state)
                {
                    state.Value += value;
                    AddState(state);
                }
            }
        }
        public void ModifyStateValue(string stateName, int value)
        {
            if (HasState(stateName))
            {
                GetState(stateName).Value += value;
                if (GetState(stateName).Value <= 0)
                {
                    RemoveState(stateName);
                }
            }
        }

        public void SetStateValue(State state, int value)
        {
            if (HasState(state))
            {
                GetState(state).Value = value;

                if (GetState(state).Value <= 0)
                {
                    RemoveState(state);
                }
            }
            else
            {
                if (state)
                {
                    state.Value = value;
                    AddState(state);
                }
            }
        }
        public void SetStateValue(string stateName, int value)
        {
            if (HasState(stateName))
            {
                GetState(stateName).Value = value;
                if (GetState(stateName).Value <= 0)
                {
                    RemoveState(stateName);
                }
            }
        }

        public void RemoveState(State state)
        {
            if (HasState(state))
            {
                states.Remove(state);
            }
        }

        public void RemoveState(string stateName)
        {
            if (HasState(stateName))
            {
                states.Remove(GetState(stateName));
            }
        }

#endregion

#region Private Methods

#endregion
    }
}