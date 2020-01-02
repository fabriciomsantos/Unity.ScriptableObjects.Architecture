using UnityEngine;

namespace ScriptableObjectsArchitecture.Variable.SO
{
    [CreateAssetMenu(fileName = "NewAudioClipVariable", menuName = "Variables/AudioClip Variable")]
    public class AudioClipVariable : ScriptableObjectVariable<AudioClip>
    { }
}