using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyToPlayer : MonoBehaviour
{
    public Transform targetTransform; // 目标位置和旋转的Transform组件
    public float animationDuration = 1.0f; // 动画持续时间

    void Start()
    {
        // 假设木块初始时是十倍大小并且可能有不同的旋转
        // transform.localScale = Vector3.one * 10;
    }

    public void ActivateAnimation()
    {
        transform.DOMove(targetTransform.position, animationDuration).SetEase(Ease.InOutQuad);
        transform.DORotateQuaternion(targetTransform.rotation, animationDuration).SetEase(Ease.InOutQuad);
        transform.DOScale(Vector3.one, animationDuration).SetEase(Ease.InOutQuad);
    }
}
