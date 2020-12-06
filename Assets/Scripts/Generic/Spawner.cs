using UnityEngine;

namespace Generic
{
    public class Spawner : MonoBehaviour
    {
        public void Spawn(GameObject obj, Vector3 position, float spread = 1f)
        {
            var randCoord = position + (Random.insideUnitSphere * spread);
            Instantiate(
                obj,
                randCoord,
                Quaternion.identity
            );
        }
    }
}
