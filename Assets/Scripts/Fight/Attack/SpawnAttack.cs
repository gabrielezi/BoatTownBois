using Generic;
using UnityEngine;

namespace Fight.Attack
{
    public class SpawnAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private GameObject objectToSpawn;
        
        private Spawner _spawner;

        private void Start()
        {
            _spawner = FindObjectOfType<Spawner>();
        }

        public void Attack()
        {
            _spawner.Spawn(objectToSpawn, gameObject.transform.position, 0);
        }
    }
}
