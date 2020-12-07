using Player;
using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class CharacterSelectionTutorialStep : MonoBehaviour, ITutorialStep
    {
        [SerializeField]
        private GameObject otherPirate;
        [SerializeField]
        private GameObject startingPirate;
        
        private bool _textShown;
        private bool _lockedFunctionality;
        private bool _selectionSwitchDone;
        private TextTransitionAnimation _textTransitionAnimation;

        private void Start()
        {
            _textTransitionAnimation = gameObject.GetComponent<TextTransitionAnimation>();
            otherPirate.SetActive(false);
            CharacterSelect.Instance.AddCharacter(otherPirate);
            if (CharacterSelect.Instance.IsCharacterSelected(otherPirate))
            {
                CharacterSelect.Instance.ToggleCharacterSelection(otherPirate);
            }
        }
        
        public bool Process()
        {
            if (_lockedFunctionality)
            {
                Unlock();
            }
            if (!_textShown)
            {
                _textTransitionAnimation.Animate(
                    "New pirate arrived! You can switch selection by hovering on a pirate with mouse and pressing S key."
                );
                otherPirate.SetActive(true);
                _textShown = true;
            }
            if (!_selectionSwitchDone && CharacterSelect.Instance.IsCharacterSelected(otherPirate))
            {
                _textTransitionAnimation.Animate(
                    "Amazing! Now you can try toggling selection by hovering on a pirate and pressing LeftShift+S."
                );
                _selectionSwitchDone = true;
            }
            else if (
                _selectionSwitchDone
                && (!CharacterSelect.Instance.IsCharacterSelected(otherPirate)
                    || CharacterSelect.Instance.IsCharacterSelected(startingPirate))
            )
            {
                return true;
            }

            return false;
        }

        public void LockFunctionality()
        {
            FindObjectOfType<CharacterSelector>().enabled = false;
            _lockedFunctionality = true;
        }

        private void Unlock()
        {
            FindObjectOfType<CharacterSelector>().enabled = true;
            _lockedFunctionality = false;
        }
    }
}