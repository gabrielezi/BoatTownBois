using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    public class TextTransitionAnimation : MonoBehaviour
    {
        private Canvas _canvas;
        private Text _text;
        private RectTransform _popUpBackgroundRT;

        private void Start()
        {
            _text = GameObject.Find("Pop-ups_Text").GetComponent<Text>();
            _popUpBackgroundRT = GameObject.Find("Pop-ups_Background").GetComponent<RectTransform>();
        }

        public void Animate(string text)
        {
            StartCoroutine(AnimateTextTransition(text));
        }

        private IEnumerator AnimateTextTransition(string message)
        {
            var color = _text.color;
            var waitFixedUpdate = new WaitForFixedUpdate();
            var animationSpeed = 16;

            for (float ft = 1f; ft >= 0; ft -= 0.1f)
            {
                color.a = ft;
                _text.color = color;

                yield return waitFixedUpdate;
            }

            var height = 240;
            while (height > animationSpeed)
            {
                _popUpBackgroundRT.sizeDelta = new Vector2(_popUpBackgroundRT.sizeDelta.x, height);
                height -= animationSpeed;

                yield return waitFixedUpdate;
            }

            while (height < 240)
            {
                _popUpBackgroundRT.sizeDelta = new Vector2(_popUpBackgroundRT.sizeDelta.x, height);
                height += animationSpeed;

                yield return waitFixedUpdate;
            }

            _text.text = message;
            for (float ft = 0f; ft <= 1f; ft += 0.1f)
            {
                color.a = ft;
                _text.color = color;

                yield return waitFixedUpdate;
            }
        }
    }
}
