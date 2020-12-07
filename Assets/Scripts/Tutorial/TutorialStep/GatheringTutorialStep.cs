using System.Collections;
using Fight.Destroy;
using Generic;
using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class GatheringTutorialStep : MonoBehaviour, ITutorialStep
    {
        [SerializeField] private OnDestroyDispatcher onDestroyDispatcher;
        [SerializeField] private GameObject resourceToGather;

        private bool _textShown;
        private bool _lockedFunctionality;
        private bool _resourceGathered;
        private bool _spotlight;
        private TextTransitionAnimation _textTransitionAnimation;
        private ObjectSpotlight _objectSpotlight;

        private void Start()
        {
            _textTransitionAnimation = gameObject.GetComponent<TextTransitionAnimation>();
            onDestroyDispatcher.OnObjectDestroyed += OnGameObjectDestroyed;
            _objectSpotlight = GameObject.Find("Point_Light").GetComponent<ObjectSpotlight>();
        }

        private void OnGameObjectDestroyed(GameObject destroyedObject)
        {
            _resourceGathered = destroyedObject.CompareTag("Stone");
        }

        public bool Process()
        {
            if (_lockedFunctionality)
            {
                Unlock();
            }

            if (!_spotlight)
            {
                _objectSpotlight.SpotlightGameObject(resourceToGather, 2f);
                _spotlight = true;
            }
            else if (!_textShown)
            {
                _textTransitionAnimation.Animate("See this stone? Try to gather it using your right mouse button.");
                _textShown = true;
            }

            return _resourceGathered;
        }

        public void LockFunctionality()
        {
            resourceToGather.GetComponent<Gathering>().enabled = false;
            _lockedFunctionality = true;
        }

        private void Unlock()
        {
            resourceToGather.GetComponent<Gathering>().enabled = true;
            _lockedFunctionality = false;
        }
    }
}
