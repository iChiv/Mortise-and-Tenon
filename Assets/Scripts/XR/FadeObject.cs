using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeObject : MonoBehaviour
{
    public float fadeDuration = 0.5f;

    private Renderer _renderer; // 当前GameObject的Renderer组件（如果有的话）

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void FadeOutAndDisable()
    {
        if (_renderer != null)
        {
            // 直接对当前GameObject应用渐隐效果
            FadeOutRenderer(_renderer, () => gameObject.SetActive(false));
        }
        else
        {
            // 遍历所有子物体并应用渐隐效果
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                FadeOutRenderer(renderer, () => renderer.gameObject.SetActive(false));
            }
            
            // 可选：所有子物体渐隐后禁用父物体
            DOVirtual.DelayedCall(fadeDuration, () => gameObject.SetActive(false));
        }
    }

    public void EnableAndFadeIn()
    {
        gameObject.SetActive(true); // 激活当前GameObject

        if (_renderer != null)
        {
            FadeInRenderer(_renderer);
        }
        else
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>(true);
            foreach (Renderer renderer in renderers)
            {
                renderer.gameObject.SetActive(true); // 激活子物体
                FadeInRenderer(renderer);
            }
        }
    }

    private void FadeOutRenderer(Renderer renderer, TweenCallback onComplete)
    {
        Material mat = renderer.material;
        mat.DOFade(0, fadeDuration).OnComplete(onComplete);
    }

    private void FadeInRenderer(Renderer renderer)
    {
        Material mat = renderer.material;
        mat.DOFade(0, 0); // 确保从完全透明开始
        mat.DOFade(1, fadeDuration);
    }
}
