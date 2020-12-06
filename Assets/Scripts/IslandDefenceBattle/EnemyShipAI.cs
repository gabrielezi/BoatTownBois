using Generic;
using UnityEngine;

namespace IslandDefenceBattle
{
    public class EnemyShipAI : MonoBehaviour
    {
        public GameObject[] crew;
        
        public Vector3 endPosition = new Vector3(0f, 2.5f);
        public float speed = 0.02f;
        private bool _spawnedCrew;

        private Spawner _spawner;

        private void Start()
        {
            _spawner = FindObjectOfType<Spawner>();
        }

        private void FixedUpdate()
        {
            if (transform.position != endPosition)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    endPosition,
                    speed
                );
            } else if (!_spawnedCrew)
            {
                SpawnCrew(endPosition);
                _spawnedCrew = true;
            }
        }

        private void SpawnCrew(Vector3 position)
        {
            foreach (var crewMember in crew)
            {
                _spawner.Spawn(crewMember, position);
            }
        }
    }
}
