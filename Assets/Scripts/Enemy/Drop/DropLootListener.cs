using Generic;
using Generic.EventGameObject;
using UnityEngine;
using EventType = Generic.EventGameObject.EventType;
using Random = UnityEngine.Random;

namespace Enemy.Drop
{
    public class DropLootListener : MonoBehaviour, IEventListener
    {
        public EventType Type { get; }

        [SerializeField] private LootItem[] lootItems;
        private Spawner _spawner;

        public DropLootListener()
        {
            Type = EventType.OnDestroy;
        }

        private void Start()
        {
            _spawner = FindObjectOfType<Spawner>();
        }

        public void OnEventReceived(GameObjectEvent gameObjectEvent)
        {
            var position = gameObject.transform.position;
            foreach (var lootItem in lootItems)
            {
                var dropAmount = Random.Range(lootItem.minAmount, lootItem.maxAmount);
                for (int i = 0; i < dropAmount; i++)
                {
                    _spawner.Spawn(lootItem.item, position);
                }
            }
        }
    }
}
