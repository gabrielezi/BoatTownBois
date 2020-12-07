using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class CameraMovementTutorialStep : MonoBehaviour, ITutorialStep
    {
        private bool _textShown;
        private bool _lockedFunctionality;
        private TextTransitionAnimation _textTransitionAnimation;
        private Camera _camera;
        private Vector3 _startCameraPosition;

        private void Start()
        {
            _textTransitionAnimation = gameObject.GetComponent<TextTransitionAnimation>();
            _camera = Camera.main;
            _startCameraPosition = _camera.transform.position;
        }
        
        public bool Process()
        {
            if (_lockedFunctionality)
            {
                Unlock();
            }
            if (!_textShown)
            {
                _textTransitionAnimation.Animate("Now try to move the camera by putting your mouse cursor near a screen border.");
                _textShown = true;
            }
            
            return _textShown && _camera.transform.position != _startCameraPosition;
        }

        public void LockFunctionality()
        {
            FindObjectOfType<CameraMovement>().enabled = false;
            _lockedFunctionality = true;
        }

        private void Unlock()
        {
            FindObjectOfType<CameraMovement>().enabled = true;
            _lockedFunctionality = false;
        }
    }
}