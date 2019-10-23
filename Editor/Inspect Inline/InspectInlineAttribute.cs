using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsArchitecture.Inspector
{

    public class InspectInlineAttribute : PropertyAttribute
    {
        public bool canEditRemoteTarget;

        public bool canCreateSubasset;
    }

}
