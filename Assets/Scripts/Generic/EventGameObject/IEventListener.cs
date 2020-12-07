namespace Generic.EventGameObject
{
    public interface IEventListener
    {
        EventType Type { get; }
        void OnEventReceived(GameObjectEvent gameObjectEvent);
    }
}
