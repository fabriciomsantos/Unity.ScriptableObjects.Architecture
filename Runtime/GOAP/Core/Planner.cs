using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    public class Node
    {
        public Node parent;
        public float cost;
        public List<State> states;
        public ActionBase action;

        public Node(Node parent, float cost, List<State> allstates, ActionBase action)
        {
            this.parent = parent;
            this.cost = cost;
            states = new List<State>(allstates);
            this.action = action;
        }

        public Node(Node parent, float cost, List<State> worldStates, List<State> agentStates, ActionBase action)
        {
            this.parent = parent;
            this.cost = cost;
            states = new List<State>(worldStates);
            states.AddRange(agentStates.Where(agentState => !states.Contains(agentState)));
            this.action = action;
        }
    }

    public class Planner
    {
#region Public Variables

#endregion

#region Protected Variables

#endregion

#region Private Variables

#endregion

#region Properties

#endregion

#region Public Methods
        public Queue<ActionBase> Plan(List<ActionBase> actions, List<State> goals, ObjectStates worldStates, ObjectStates agentStates)
        {
            var usableActions = new List<ActionBase>();
            foreach (var action in actions)
            {
                if (action.IsAchievable())
                {
                    usableActions.Add(action);
                }
            }

            var leaves = new List<Node>();
            var startNode = new Node(null, 0, worldStates?.States, agentStates?.States, null);

            bool success = BuildGraph(startNode, leaves, usableActions, goals);

            if (!success)
            {
                return null;
            }

            Node cheapestNode = null;
            foreach (var leaf in leaves)
            {
                if (cheapestNode == null)
                {
                    cheapestNode = leaf;
                }
                else if (leaf.cost < cheapestNode.cost)
                {
                    cheapestNode = leaf;
                }
            }

            var result = new List<ActionBase>();

            var node = cheapestNode;

            while (node != null)
            {
                if (node.action != null)
                {
                    result.Insert(0, node.action);
                }
                node = node.parent;
            }

            var queue = new Queue<ActionBase>();

            foreach (var action in result)
            {
                queue.Enqueue(action);
            }

            return queue;
        }

#endregion

#region Private Methods
        private bool BuildGraph(Node parent, List<Node> leaves, List<ActionBase> usableActions, List<State> goals)
        {
            bool foundPath = false;

            foreach (var action in usableActions)
            {
                if (action.IsAchievableGiven(parent.states))
                {
                    var currentStates = new List<State>(parent.states);

                    foreach (var effect in action.effects)
                    {
                        if (!currentStates.Contains(effect))
                        {
                            currentStates.Add(effect);
                        }
                    }
                    var node = new Node(parent, parent.cost + action.cost, currentStates, action);
                    if (GoalAchieved(goals, currentStates))
                    {
                        leaves.Add(node);
                        foundPath = true;
                    }
                    else
                    {
                        List<ActionBase> subset = ActionSubSet(usableActions, action);

                        foundPath = BuildGraph(node, leaves, subset, goals);
                    }
                }
            }
            return foundPath;
        }

        private bool GoalAchieved(List<State> goals, List<State> state)
        {
            foreach (var goal in goals)
            {
                if (!state.Contains(goal))
                {
                    return false;
                }
            }
            return true;
        }

        private List<ActionBase> ActionSubSet(List<ActionBase> actions, ActionBase removedAction)
        {
            var subset = new List<ActionBase>();
            foreach (var action in actions)
            {
                if (!action.Equals(removedAction))
                {
                    subset.Add(action);
                }
            }
            return subset;
        }

#endregion
    }
}