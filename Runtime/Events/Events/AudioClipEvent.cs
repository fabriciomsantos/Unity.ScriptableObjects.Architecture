
using UnityEngine;

namespace ScriptableObjectsArchitecture.Events.SO
{
    /// <summary>
    /// Create file inside project
    /// </summary>
    [CreateAssetMenu(fileName = "NewAudioClipEvent", menuName = "Events/AudioClip Event")]
    public class AudioClipEvent : BaseGameEvent<AudioClip>{} 
}