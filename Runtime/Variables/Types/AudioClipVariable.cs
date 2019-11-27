using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.Object
{
    [CreateAssetMenu(fileName = "NewAudioClipVariable", menuName = "Variables/AudioClip Variable")]
    public class AudioClipVariable : ScriptableObjectVariable<AudioClip>
    { }
}