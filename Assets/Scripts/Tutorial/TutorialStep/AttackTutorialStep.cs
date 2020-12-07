using Player;
using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class AttackTutorialStep : MonoBehaviour, ITutorialStep
    {
        private bool _textShown;
        private bool _lockedFunctionality;
        private TextTransitionAnimation _textTransitionAnimation;

        private void Start()
        {
            _textTransitionAnimation = gameObject.GetComponent<TextTransitionAnimation>();
        }

        public bool Process()
        {
            if (_lockedFunctionality)
            {
                Unlock();
            }

            if (!_textShown)
            {
                _textTransitionAnimation.Animate("Attack by pressing F key.");
                _textShown = true;
            }

            return Input.GetKeyDown(KeyCode.F);
        }

        public void LockFunctionality()
        {
            CharacterSelect.Instance.GetOneSelectedCharacter().GetComponent<PlayerAttack>().enabled = false;
            _lockedFunctionality = true;
        }

        private void Unlock()
        {
            CharacterSelect.Instance.GetOneSelectedCharacter().GetComponent<PlayerAttack>().enabled = true;
            _lockedFunctionality = false;
        }
    }
}
