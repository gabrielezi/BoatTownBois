using UnityEngine;

namespace Generic.EventGameObject
{
    public class GameObjectEvent
    {
        public GameObject Data { get; }
        public EventType Type { get; }

        public GameObjectEvent(GameObject data, EventType type)
        {
            Data = data;
            Type = type;
        }
    }
}
