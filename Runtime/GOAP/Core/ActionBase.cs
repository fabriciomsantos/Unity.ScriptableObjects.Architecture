using System.Collections;
using System.Collections.Generic;

using ScriptableObjectsArchitecture.Events.Reference;

using UnityEngine;

namespace ScriptableObjectsArchitecture.GOAP
{
    public abstract class ActionBase : MonoBehaviour
    {
#region Public Variables
        public TargetType targetType;
        public float cost = 1;
        public GameObject target;
        public float duration = 0;

        [Header("States")]
        public List<State> conditions = new List<State>();
        public List<State> effects = new List<State>();

        [Header("Events")]
        public VoidEventReference EnterActionEvent;
        public VoidEventReference ExitActionEvent;

        [Space(10)]
        public bool executing;

#endregion

#region Protected Variables

#endregion

#region Private Variables

#endregion

#region Properties

#endregion

#region Unity Methods

#endregion

#region Public Methods

        public virtual bool IsAchievable()
        {
            return true;
        }
        public bool IsAchievableGiven(List<State> stateConditions)
        {
            foreach (var condition in conditions)
            {
                if (!stateConditions.Contains(condition))
                {
                    return false;
                }
            }
            if (targetType && targetType.Queue.Count == 0)
            {
                return false;
            }
            return true;
        }

        public bool PrePerform()
        {
            if (targetType)
            {
                target = targetType.UseResource();
                if (target)
                {
                    EnterActionEvent.Raise();
                    return EnterAction();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                EnterActionEvent.Raise();
                return EnterAction();
            }
        }
        public bool PostPerform()
        {
            if (targetType && target)
            {
                targetType.FinishedResourceUsage(target);
            }

            ExitActionEvent.Raise();
            return ExitAction();
        }

        public abstract bool EnterAction();
        public abstract bool ExitAction();

#endregion

#region Private Methods

#endregion
    }
}