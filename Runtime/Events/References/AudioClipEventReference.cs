using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class AudioClipEventReference : ScriptableObjectEventReference<AudioClip, AudioClipEvent, UnityAudioClipEvent>
    { }
}