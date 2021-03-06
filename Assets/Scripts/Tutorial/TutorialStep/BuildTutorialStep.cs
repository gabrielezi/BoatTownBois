﻿using Player;
using UnityEngine;

namespace Tutorial.TutorialStep
{
    public class BuildTutorialStep : MonoBehaviour, ITutorialStep
    {
        private bool _textShown;
        private bool _lockedFunctionality;
        private bool _building;
        private float _buildTimer;
        private int _currentStone;
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
                _textTransitionAnimation.Animate(
                    "Now you have enough resources to build. Move to a position you want and press B key to open build menu."
                );
                _textShown = true;
                _currentStone = ResourceManager.Instance.GetResource(ResourceEnum.Stone);
            }
            else if (!_building && _currentStone > ResourceManager.Instance.GetResource(ResourceEnum.Stone))
            {
                _building = true;
                _buildTimer = Time.time + CharacterSelect.Instance.GetOneSelectedCharacter().GetComponent<PlayerBuild>().GetBuildTime();
            }
            else if (_building && Time.time > _buildTimer)
            {
                return true;
            }

            return false;
        }

        public void LockFunctionality()
        {
            CharacterSelect.Instance.GetOneSelectedCharacter().GetComponent<PlayerBuild>().enabled = false;
            _lockedFunctionality = true;
        }

        private void Unlock()
        {
            CharacterSelect.Instance.GetOneSelectedCharacter().GetComponent<PlayerBuild>().enabled = true;
            _lockedFunctionality = false;
        }
    }
}
