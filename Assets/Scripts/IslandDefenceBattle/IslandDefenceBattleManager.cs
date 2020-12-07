using UnityEngine;

namespace IslandDefenceBattle
{
    public class IslandDefenceBattleManager : MonoBehaviour
    {
        [SerializeField] private Ship[] ships;

        public void BattleStart()
        {
            SoundManager.Instance.PlayBackgroundSound("Island Defence Battle");
            foreach (var ship in ships)
            {
                var shipGameObject = Instantiate(
                    ship.ship,
                    ship.startPosition,
                    Quaternion.identity
                );
                var shipControl = shipGameObject.GetComponent<EnemyShipAI>();
                shipControl.endPosition = ship.endPosition;
                shipControl.crew = ship.crew;
                shipControl.speed = ship.speed;
                shipControl.transform.Rotate(new Vector3(0, 0, 90));
            }
        }
    }
}
