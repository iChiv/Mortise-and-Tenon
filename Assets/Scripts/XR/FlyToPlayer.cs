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
    public float floatingDuration = 2f; // 飘浮动画的持续时间
    
    public GameObject handGrab;
    public GameObject distanceHandGrab;

    void Start()
    {
        // 假设木块初始时是十倍大小并且可能有不同的旋转
        // transform.localScale = Vector3.one * 3;
        handGrab = transform.Find("ISDK_HandGrabInteraction").gameObject; 
        distanceHandGrab = transform.Find("ISDK_DistanceHandGrabInteraction").gameObject; 
        DisableGrab();
    }

    public void MoveToPlayer()
    {
        // transform.DOMove(targetTransform.position, animationDuration).SetEase(Ease.InOutQuad);
        // transform.DORotateQuaternion(targetTransform.rotation, animationDuration).SetEase(Ease.InOutQuad);
        // transform.DOScale(Vector3.one, animationDuration).SetEase(Ease.InOutQuad);
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
        transform.DOKill();
        MoveToPlayer();
    }
    
    void StartFloatingAnimation(GameObject block)
    {
        // 生成随机路径点
        Vector3[] path = GenerateRandomPathPoints(transform.position, floatingRadius, 5);
        // 设置循环的路径动画
        transform.DOPath(path, floatingDuration, PathType.CatmullRom)
            .SetOptions(true)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }
    
    Vector3[] GenerateRandomPathPoints(Vector3 center, float radius, int pointsCount)
    {
        Vector3[] path = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            float angle = i * (360f / pointsCount) * Mathf.Deg2Rad;
            path[i] = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        }
        return path;
    }
}
