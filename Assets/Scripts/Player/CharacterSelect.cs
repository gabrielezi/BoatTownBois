using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CharacterSelect : MonoBehaviour
    {
        public static CharacterSelect Instance;

        private Dictionary<GameObject, SpriteRenderer> _selectedCharacters;

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
        }

        private void Start()
        {
            _selectedCharacters = new Dictionary<GameObject, SpriteRenderer>();
            foreach (Transform t in FindObjectOfType<CharacterSelector>().transform)
            {
                _selectedCharacters.Add(t.gameObject, t.Find("Alert_Selected").gameObject.GetComponent<SpriteRenderer>());
            }
        }

        public void SetSelectedCharacter(GameObject selected)
        {
            foreach (var selectedCharacter in _selectedCharacters)
            {
                selectedCharacter.Value.enabled = selected == selectedCharacter.Key;
            }
        }

        public bool IsCharacterSelected(GameObject character)
        {
            return _selectedCharacters.TryGetValue(character, out var characterSelected) && characterSelected.enabled;
        }

        public GameObject GetOneSelectedCharacter()
        {
            foreach (var selectedCharacter in _selectedCharacters)
            {
                if (selectedCharacter.Value.enabled)
                {
                    return selectedCharacter.Key;
                }
            }

            return null;
        }

        public void ToggleCharacterSelection(GameObject character)
        {
            if (_selectedCharacters.TryGetValue(character, out var characterSelected))
            {
                characterSelected.enabled = !characterSelected.enabled;
            }
        }

        public int GetSelectedCharacterCount()
        {
            int selectedCount = 0;
            foreach (var alertSprite in _selectedCharacters.Values)
            {
                if (alertSprite.enabled)
                {
                    selectedCount++;
                }
            }

            return selectedCount;
        }

        public void AddCharacter(GameObject character)
        {
            if (_selectedCharacters.ContainsKey(character))
            {
                return;
            }

            var sr = character.GetComponent<SpriteRenderer>();
            sr.enabled = false;
            _selectedCharacters.Add(character, sr);
        }

        public void RemoveCharacter(GameObject character)
        {
            _selectedCharacters.Remove(character);
        }
    }
}
