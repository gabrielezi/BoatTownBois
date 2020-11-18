using IslandDefenceBattle;
using UnityEngine;

namespace GameTime
{
    public class TimedEventManager : MonoBehaviour
    {
        private IslandDefenceBattleManager _islandDefenceBattle;
        private bool _islandDefenceBattleActive;

        private void Start()
        {
            _islandDefenceBattle = FindObjectOfType<IslandDefenceBattleManager>();
        }

        public void ActivateTimedEvents(GameTime gameTime)
        {
            if (!_islandDefenceBattleActive && gameTime.Hours == 10)
            {
                _islandDefenceBattle.BattleStart();
                _islandDefenceBattleActive = true;
            }
        }
    }
}
