using System.Collections;
using UnityEngine;

namespace Enemy.Drop
{
    public class CollectableDropAnimation : MonoBehaviour
    {
        private bool _animationFinished;

        private Vector3 _startPos;
        
        private void Start()
        {
            _startPos = transform.position;
            
            StartCoroutine(Animate());
        }

        private IEnumerator Animate()
        {
            var targetPosition = _startPos;
            targetPosition.y += Random.Range(0.3f, 1.2f);
            var speed = Random.Range(1.5f, 2.5f);
            
            while (!_animationFinished)
            {
                AnimateStep(targetPosition, speed);

                yield return null;
            }

            speed = Random.Range(2.5f, 3.5f);
            _animationFinished = false;
            while (!_animationFinished)
            {
                AnimateStep(_startPos, speed);

                yield return null;
            }
        }

        private void AnimateStep(Vector3 targetPosition, float speed)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
            if (transform.position == targetPosition)
            {
                _animationFinished = true;
            }
        }
    }
}