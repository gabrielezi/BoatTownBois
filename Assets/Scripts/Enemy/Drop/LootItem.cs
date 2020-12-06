using UnityEngine;

namespace Enemy.Drop
{
    [System.Serializable]
    public class LootItem
    {
        public GameObject item;
        public int minAmount;
        public int maxAmount;
    }
}