using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class MovementTutorialStep : MonoBehaviour, ITutorialStep
    {
        private bool _textShown;
        private TextTransitionAnimation _textTransitionAnimation;

        private void Start()
        {
            _textTransitionAnimation = gameObject.GetComponent<TextTransitionAnimation>();
        }

        public bool Process()
        {
            if (!_textShown)
            {
                _textTransitionAnimation.Animate("You can move by clicking left mouse button.");
                _textShown = true;
            }

            return Input.GetMouseButtonDown(0);
        }

        public void LockFunctionality()
        {
        }
    }
}
