using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class CongratulationsTutorialStep : MonoBehaviour, ITutorialStep
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
                _textTransitionAnimation.Animate("Well done! Now let's begin the real deal. Press A key to continue.");
                _textShown = true;
            }

            return Input.GetKeyDown(KeyCode.A);
        }

        public void LockFunctionality()
        {
        }
    }
}
