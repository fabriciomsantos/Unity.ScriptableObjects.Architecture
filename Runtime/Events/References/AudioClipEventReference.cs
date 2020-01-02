using ScriptableObjectsArchitecture.Events.SO;

using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.Reference
{
    [System.Serializable]
    public class AudioClipEventReference : ScriptableObjectEventReference<AudioClip, AudioClipEvent, UnityAudioClipEvent>
    { }
}