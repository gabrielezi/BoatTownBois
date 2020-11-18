using UnityEngine;

namespace IslandDefenceBattle
{
    [System.Serializable]
    public class Ship
    {
        public GameObject[] crew;
        public GameObject ship;
        public Vector3 startPosition;
        public Vector3 endPosition;
        public float speed;
    }
}