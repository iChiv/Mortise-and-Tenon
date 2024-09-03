using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line to use SceneManager

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
                    // Display for a specified duration then fade out
                    DOVirtual.DelayedCall(displayDuration, () =>
                    {
                        nextObjectSpriteRenderer.DOFade(0, fadeDuration).OnComplete(CheckAndSwitchScene);
                    });
                });
            }
        }

        private void CheckAndSwitchScene()
        {
            // Assuming "资源 23" is a sprite reference or identifier you have
            if (nextObjectSpriteRenderer.name == "资源 23")
            {
                // Wait for 5 seconds before switching scenes
                DOVirtual.DelayedCall(5f, () =>
                {
                    SceneManager.LoadScene("GameMainMenuTT");
                });
            }
        }
    }
}