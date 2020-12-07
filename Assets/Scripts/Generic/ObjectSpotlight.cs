using System;
using System.Collections;
using UnityEngine;

namespace Generic
{
    public class ObjectSpotlight : MonoBehaviour
    {
        [SerializeField] private Light mainLight;
        [SerializeField] private float camMovementSpeed = 3f;

        private Light _spotlightLight;
        private Camera _mainCamera;

        private void Start()
        {
            _spotlightLight = gameObject.GetComponent<Light>();
            _mainCamera = Camera.main;
        }

        public void SpotlightGameObject(GameObject objectToSpotlight, float duration)
        {
            StartCoroutine(Spotlight(objectToSpotlight, duration));
        }

        private IEnumerator Spotlight(GameObject objectToSpotlight, float duration)
        {
            var startPosition = _mainCamera.transform.position;
            var targetPosition = objectToSpotlight.transform.position;
            targetPosition.z = startPosition.z;
            while (_mainCamera.transform.position != targetPosition)
            {
                _mainCamera.transform.position = Vector3.MoveTowards(
                    _mainCamera.transform.position,
                    targetPosition,
                    camMovementSpeed * Time.deltaTime
                );

                yield return null;
            }

            mainLight.enabled = false;
            _spotlightLight.enabled = true;

            yield return new WaitForSeconds(duration);

            mainLight.enabled = true;
            _spotlightLight.enabled = false;

            while (_mainCamera.transform.position != startPosition)
            {
                _mainCamera.transform.position = Vector3.MoveTowards(
                    _mainCamera.transform.position,
                    startPosition,
                    camMovementSpeed * Time.deltaTime
                );

                yield return null;
            }
        }
    }
}
