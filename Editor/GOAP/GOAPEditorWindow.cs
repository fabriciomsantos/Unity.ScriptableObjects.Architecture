using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ScriptableObjectsArchitecture.EditorTools.Window;

using UnityEditor;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP.Window
{
    public class GOAPEditorWindow : ExtendedEditorWindow
    {
#region Public Variables
        public GOAPManager gOAPManager;
        public AgentBase[] allAgents;

        public bool showAllAgents;

#endregion

#region Protected Variables

#endregion

#region Private Variables
        private Vector2 scrollPos;

#endregion

#region Properties

#endregion

#region Unity Methods

        /// <summary>
        ///  Call Repaint on OnInspectorUpdate as it repaints the windows
        ///  less times as if it was OnGUI/Update
        /// </summary>
        void OnInspectorUpdate()
        {
            if (!gOAPManager)
            {
                gOAPManager = FindObjectOfType<GOAPManager>();
            }
            allAgents = FindObjectsOfType<AgentBase>();

            Repaint();
        }

        /// <summary>
        /// OnGUI is called for rendering and handling GUI events.
        /// This function can be called multiple times per frame (one call per event).
        /// </summary>
        private void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            EditorGUILayout.LabelField("Manager", EditorStyles.boldLabel);
            if (gOAPManager)
            {
                DrawManager();
            }
            else
            {
                EditorGUILayout.LabelField("Missing manager on scene", EditorStyles.largeLabel);
            }

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Agents", EditorStyles.boldLabel);

            if (allAgents?.Length > 0)
            {
                if (GUILayout.Button("Show All Agents"))
                {
                    showAllAgents = !showAllAgents;
                }

                if (GUILayout.Button("Select All Agents"))
                {
                    Selection.objects = allAgents?.Select(agent => agent.gameObject)?.ToArray();
                }

                if (showAllAgents)
                {
                    foreach (var agent in allAgents)
                    {
                        DrawAgent(agent);
                    }
                }
                else if (Selection.gameObjects.Length > 0)
                {
                    foreach (var go in Selection.gameObjects)
                    {
                        var agent = go.GetComponent<AgentBase>();
                        DrawAgent(agent);
                    }
                }
                else
                {
                    EditorGUILayout.LabelField("Select an agent on the scene", EditorStyles.boldLabel);
                }
            }
            else
            {
                EditorGUILayout.LabelField("Missing agents on scene", EditorStyles.largeLabel);
            }
            EditorGUILayout.EndScrollView();
        }

#endregion

#region Public Methods
        [MenuItem("Window/GOAP")]
        public static void ShowWindow()
        {
            GetWindow<GOAPEditorWindow>("GOAP");
        }

        public void DrawManager()
        {
            if (gOAPManager)
            {
                EditorGUILayout.LabelField("World States: ");
                foreach (var state in gOAPManager.WorldStates.States)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUILayout.LabelField("Name:  " + state.name);
                    EditorGUILayout.LabelField("    Value: " + state.Value);
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("World Targets: ");

                foreach (var targetType in gOAPManager.targetTypes)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUILayout.LabelField("Name:  " + targetType.name);
                    EditorGUILayout.LabelField("    Amount:  " + targetType.Amount);
                    EditorGUILayout.LabelField("    Quantity: " + targetType.Queue.Count);
                    EditorGUILayout.EndVertical();
                }
            }
        }

        public void DrawAgent(AgentBase agent)
        {
            if (agent)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("Name: " + agent.name, EditorStyles.boldLabel);
                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("Current Action: " + agent?.CurrentAction?.name);
                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("Current target: " + agent?.CurrentAction?.target?.name);
                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("Actions: ");
                foreach (var action in agent.Actions)
                {
                    EditorGUILayout.Space(3);
                    EditorGUILayout.LabelField("    Name: " + action.name);
                    EditorGUILayout.LabelField("        Conditions:");
                    foreach (var condition in action.conditions)
                    {
                        EditorGUILayout.LabelField("            " + condition.name);
                    }
                    EditorGUILayout.LabelField("        Effects:");
                    foreach (var effect in action.effects)
                    {
                        EditorGUILayout.LabelField("            " + effect.name);
                    }
                }

                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("Goals: ");
                foreach (var goal in agent.Goals)
                {
                    EditorGUILayout.LabelField("    " + goal.name);
                }

                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("Action Queue: ");
                if (agent.ActionQueue != null)
                {
                    foreach (var action in agent?.ActionQueue?.ToArray())
                    {
                        EditorGUILayout.LabelField("    " + action.name);
                    }
                }

                EditorGUILayout.Space(5);
                EditorGUILayout.LabelField("Agent States: ");
                foreach (var state in agent.MyState.States)
                {
                    EditorGUILayout.LabelField("    " + state.name);
                }

                if (GUILayout.Button("Select Asset"))
                {
                    Selection.activeGameObject = agent.gameObject;
                }
                EditorGUILayout.EndVertical();
            }
        }

#endregion

#region Protected Methods

#endregion

#region Private Methods

#endregion
    }
}