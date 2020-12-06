using UnityEngine;

namespace Generic.EventGameObject
{
    public class EventDispatcher : MonoBehaviour
    {
        public void Dispatch(GameObjectEvent gameObjectEvent)
        {
            var listeners = gameObjectEvent.Data.GetComponents<IEventListener>();
            foreach (var listener in listeners)
            {
                if (listener.Type == gameObjectEvent.Type)
                {
                    listener.OnEventReceived(gameObjectEvent);
                }
            }
        }
    }
}