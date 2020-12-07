using Tutorial.TutorialStep;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        private int _index = 0;
        private ITutorialStep[] _tutorialSteps;
        private int _maxStepIndex;

        private void Start()
        {
            _tutorialSteps = gameObject.GetComponents<ITutorialStep>();
            foreach (var tutorialStep in _tutorialSteps)
            {
                tutorialStep.LockFunctionality();
            }
            _maxStepIndex = _tutorialSteps.Length - 1;
        }

        private void Update()
        {
            if (_index > _maxStepIndex || Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene(1);
            }
            else if (_tutorialSteps[_index].Process())
            {
                _index++;
            }
        }
    }
}