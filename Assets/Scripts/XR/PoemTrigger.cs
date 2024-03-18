using DG.Tweening;
using UnityEngine;

namespace XR
{
    public class PoemTrigger : MonoBehaviour
    {
        public SpriteRenderer nextObjectSpriteRenderer;

        public float displayDuration = 10f;

        public float fadeDuration = 2f;

        private void Awake()
        {
            nextObjectSpriteRenderer.DOFade(0, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("poem"))
            {
                nextObjectSpriteRenderer.DOFade(1, fadeDuration).OnComplete(() =>
                {
                    // 显示一段时间后渐隐
                    DOVirtual.DelayedCall(displayDuration, () =>
                    {
                        nextObjectSpriteRenderer.DOFade(0, fadeDuration);
                    });
                });
            }
        }
    }
}
