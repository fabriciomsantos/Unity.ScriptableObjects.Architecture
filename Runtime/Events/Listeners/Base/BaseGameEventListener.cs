using ScriptableObjectsArchitecture.Events.SO;
using ScriptableObjectsArchitecture.Inspector;

using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsArchitecture.Events.Listeners
{
    public abstract class BaseGameEventListener<T, GE, UER> : MonoBehaviour where GE : BaseGameEvent<T> where UER : UnityEvent<T>, new()
    {
        [InspectInline(canEditRemoteTarget = true)]
        public GE gameEvent;

        public UER unityEventResponse = new UER();

        protected void OnEnable()
        {
            Subscribe(gameEvent);
        }

        protected void OnDisable()
        {
            Unsubscribe();
        }

        public void Subscribe(GE _gameEvent)
        {
            gameEvent = _gameEvent;
            if (gameEvent is null)
            {
                Debug.LogWarning("GameEvent is null");
                return;
            }

            gameEvent.EventListeners += TriggerResponses; // Subscribe
        }

        public GE Unsubscribe()
        {
            if (gameEvent is null)
            {
                Debug.LogWarning("GameEvent is null");
                return null;
            }

            gameEvent.EventListeners -= TriggerResponses; // Unsubscribe
            return gameEvent;
        }

        public void TriggerResponses(T val)
        {
            //No need to nullcheck here, UnityEvents do that for us (lets avoid the double nullcheck)
            unityEventResponse.Invoke(val);
        }
    }
}