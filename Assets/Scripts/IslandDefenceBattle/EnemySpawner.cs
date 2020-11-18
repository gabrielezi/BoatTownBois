using UnityEngine;

namespace IslandDefenceBattle
{
    public class EnemySpawner : MonoBehaviour
    {
        public void Spawn(GameObject enemy, Vector3 position)
        {
            var randCoord = Random.Range(-1f, 1f);
            Instantiate(
                enemy,
                new Vector3(position.x + randCoord, position.y + randCoord),
                Quaternion.identity
            );
        }
    }
}
