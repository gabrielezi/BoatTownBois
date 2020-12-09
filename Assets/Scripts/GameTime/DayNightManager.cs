using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameTime
{
    public class DayNightManager : MonoBehaviour
    {
        public static DayNightManager Instance;
        
        [SerializeField] private int uiUpdateDelayTime = 10;
        [SerializeField] private int startHours = 6;
        [SerializeField] private int minutesToAdd = 1;
        [SerializeField] private int minuteAdditionSpeedInFixedFrames = 1;
        [SerializeField] private Light sceneLight;

        private GameUIManager _gameUIManager;
        private GameTime _gameTime;
        private int _uiUpdateDelayTimer = 0;
        private int _minuteAdditionDelayTimer = 0;

        private TimedEventManager _timedEventManager;

        private readonly float[] _lightIntensitiesByHour =
        {
            0.3f, // 0
            0.3f, // 1
            0.3f, // 2
            0.3f, // 3
            0.3f, // 4
            0.4f, // 5
            0.45f, // 6
            0.5f, // 7
            0.55f, // 8
            0.65f, // 9
            0.75f, // 10
            0.85f, // 11
            0.9f, // 12
            0.9f, // 13
            0.9f, // 14
            0.9f, // 15
            0.9f, // 16
            0.9f, // 17
            0.8f, // 18
            0.75f, // 19
            0.7f, // 20
            0.65f, // 21
            0.55f, // 22
            0.45f, // 23
        };
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            
            DontDestroyOnLoad(gameObject);
        }
        
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _gameUIManager = FindObjectOfType<GameUIManager>();
            _timedEventManager = FindObjectOfType<TimedEventManager>();
        }
        
        private void Start()
        {
            _gameTime = new GameTime();
            _gameTime.AddHours(startHours);
        }

        private void FixedUpdate()
        {
            ChangeTime();
            sceneLight.intensity = _lightIntensitiesByHour[_gameTime.Hours];
        }

        private void ChangeTime()
        {
            if (_timedEventManager != null)
            {
                _timedEventManager.ActivateTimedEvents(_gameTime);
            }
            _minuteAdditionDelayTimer++;
            if (_minuteAdditionDelayTimer >= minuteAdditionSpeedInFixedFrames)
            {
                _minuteAdditionDelayTimer = 0;
                _gameTime.AddMinutes(minutesToAdd);
            }

            _uiUpdateDelayTimer++;
            if (_uiUpdateDelayTimer >= uiUpdateDelayTime)
            {
                _uiUpdateDelayTimer = 0;
                _gameUIManager.UpdateDayText($"Day {_gameTime.Days}. Time {_gameTime.Hours}:{_gameTime.Minutes}");
            }
        }
    }
}
