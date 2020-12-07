using System.Collections;
using Fight.Destroy;
using Generic;
using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class DestroyShipTutorialStep : MonoBehaviour, ITutorialStep
    {
        [SerializeField] private OnDestroyDispatcher onDestroyDispatcher;
        [SerializeField] private GameObject shipToDestroy;

        private bool _textShown;
        private bool _spotlight;
        private bool _shipDestroyed;
        private bool _textCollectResourcesShown;
        private bool _resourcesCollected;
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
            _shipDestroyed = destroyedObject.CompareTag("Ship");
        }

        public bool Process()
        {
            if (!_spotlight)
            {
                _objectSpotlight.SpotlightGameObject(shipToDestroy, 2f);
                _spotlight = true;
            }
            else if (!_textShown)
            {
                _textTransitionAnimation.Animate("Try to destroy this old ship. You might get some resources.");
                _textShown = true;
            }
            else if (_shipDestroyed && !_textCollectResourcesShown)
            {
                _textTransitionAnimation.Animate("Awesome! Now you can collect dropped resources.");
                _textCollectResourcesShown = true;
            }
            else if (_shipDestroyed && ResourceManager.Instance.GetResource(ResourceEnum.Wood) >= 200)
            {
                return true;
            }

            return false;
        }

        public void LockFunctionality()
        {
        }
    }
}
