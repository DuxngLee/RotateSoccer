using UnityEngine;
using DG.Tweening;

namespace Script.Level.Controller
{
    public class TrapMove : MonoBehaviour
    {
        public Transform targetPosition;
        public Vector3   defaultPosition;
        public float     moveDuration = 2f;
        public float     waitDuration = 1f;

        private Tween moving;

        private void Start()
        {
            this.defaultPosition = this.transform.localPosition;
            this.MoveToTarget();
        }

        private void MoveToTarget()
        {
            this.moving = this.transform.DOLocalMove(this.targetPosition.localPosition, this.moveDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    this.moving = this.transform.DOLocalMove(this.defaultPosition, this.moveDuration)
                        .SetEase(Ease.Linear)
                        .OnComplete(
                            this.MoveToTarget
                        );
                });
        }

        private void OnDestroy()
        {
            this.moving.Kill(); 
        }
    }
}