using System.Collections;
using System.Collections.Generic;

using ScriptableObjectsArchitecture.RuntimeSet;

using UnityEngine;
namespace ScriptableObjectsArchitecture.GOAP
{
    [CreateAssetMenu(fileName = "NewAgentsRuntime", menuName = "GOAP/Agents Runtime")]
    public class AgentsRuntime : RuntimeSet<AgentBase>
    {
    }
}