using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyToPlayer : MonoBehaviour
{
    public Transform targetTransform; // 目标位置和旋转的Transform组件
    public float animationDuration = 1.0f; // 动画持续时间
    
    public float floatingRadius = 0.5f; // 飘浮动画中木块移动的半径
    public float floatingDuration = 30f; // 飘浮动画的持续时间
    
    private GameObject handGrab;
    private GameObject distanceHandGrab;

    void Awake()
    {
        // 假设木块初始时是十倍大小并且可能有不同的旋转
        // transform.localScale = Vector3.one * 3;
        handGrab = transform.Find("ISDK_HandGrabInteraction").gameObject; 
        distanceHandGrab = transform.Find("ISDK_DistanceHandGrabInteraction").gameObject; 
        DisableGrab();
        StartFloatingAnimation(gameObject);
    }

    public void MoveToPlayer()
    {
        transform.DOKill();
        transform.DOMove(targetTransform.position, animationDuration).SetEase(Ease.InOutQuad);
        transform.DORotateQuaternion(targetTransform.rotation, animationDuration).SetEase(Ease.InOutQuad);
        transform.DOScale(Vector3.one, animationDuration).SetEase(Ease.InOutQuad);
        EnableGrab();
    }

    public void DisableGrab()
    {
        handGrab.SetActive(false);
        distanceHandGrab.SetActive(false);
    }

    public void EnableGrab()
    {
        handGrab.SetActive(true);
        distanceHandGrab.SetActive(true);
        DOVirtual.DelayedCall(1f, () => {
            transform.DOKill();
        });
        // MoveToPlayer();
    }
    
    void StartFloatingAnimation(GameObject block)
    {
        // 生成随机路径点
        Vector3[] path = GenerateRandomPathPoints(block.transform.position, floatingRadius, 5);
        // 设置循环的路径动画
        block.transform.DOPath(path, floatingDuration, PathType.CatmullRom)
            .SetOptions(true)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.InOutQuad);
    }

    Vector3[] GenerateRandomPathPoints(Vector3 center, float radius, int pointsCount)
    {
        Vector3[] path = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            // 为每个路径点引入随机偏移，确保路径的唯一性
            float angle = UnityEngine.Random.Range(0f, 360f) * Mathf.Deg2Rad; // 随机角度
            float randomRadius = UnityEngine.Random.Range(0.5f * radius, 1.5f * radius); // 随机半径
            path[i] = center + new Vector3(Mathf.Cos(angle) * randomRadius, Mathf.Sin(angle) * randomRadius, UnityEngine.Random.Range(-radius, radius));
        }
        return path;
    }
}
