using UnityEngine;
using DG.Tweening;

public class DecorationFloating : MonoBehaviour
{
    public Sprite[] sprites; // 装饰品的Sprite数组
    public float fadeInDuration = 2f;
    public float visibleDuration = 5f;
    public float fadeOutDuration = 2f;
    public float moveDistance = 2f; // 移动距离，正值向上，负值向下

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 随机选择一个Sprite
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        // 开始时设为完全透明
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        StartFloatingAnimation();
    }

    void StartFloatingAnimation()
    {
        // 随机决定是由下至上还是由上至下渐显
        bool moveUp = Random.Range(0, 2) == 0;
        float moveDirection = moveUp ? 1 : -1;
        float startPositionY = transform.position.y - (moveDistance * moveDirection);
        transform.position = new Vector3(transform.position.x, startPositionY, transform.position.z);

        // 渐显同时向上或向下移动
        spriteRenderer.DOFade(1, fadeInDuration);
        transform.DOMoveY(transform.position.y + (moveDistance * moveDirection), fadeInDuration).SetEase(Ease.OutQuad);

        // 保持一段时间后渐隐
        DOVirtual.DelayedCall(visibleDuration, () =>
        {
            spriteRenderer.DOFade(0, fadeOutDuration);
        });
    }
}