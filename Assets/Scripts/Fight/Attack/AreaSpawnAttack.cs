using Generic;
using UnityEngine;

namespace Fight.Attack
{
    public class AreaSpawnAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private GameObject objectToSpawn;
        
        private AreaAttack _areaAttack;
        private Spawner _spawner;

        private void Start()
        {
            _spawner = FindObjectOfType<Spawner>();
            _areaAttack = gameObject.GetComponent<AreaAttack>();
        }

        public void Attack()
        {
            _spawner.Spawn(objectToSpawn, gameObject.transform.position, 0);
            _areaAttack.Attack();
        }
    }
}
