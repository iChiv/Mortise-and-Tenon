using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyToPlayer : MonoBehaviour
{
    public Transform targetTransform; // 目标位置和旋转的Transform组件
    public float animationDuration = 1.0f; // 动画持续时间
    
    public float floatingRadius = 0.3f; // 飘浮动画中木块移动的半径
    public float floatingDuration = 50f; // 飘浮动画的持续时间
    
    private GameObject handGrab;
    private GameObject distanceHandGrab;

    void Awake()
    {
        handGrab = transform.Find("ISDK_HandGrabInteraction").gameObject; 
        distanceHandGrab = transform.Find("ISDK_DistanceHandGrabInteraction").gameObject; 
        DisableGrab();
        StartFloatingAnimation(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToPlayer();
        }
    }

    public void MoveToPlayer()
    {
        transform.DOKill();

        transform.DOMove(targetTransform.position, animationDuration).SetEase(Ease.InOutQuad);
        transform.DORotateQuaternion(targetTransform.rotation, animationDuration).SetEase(Ease.InOutQuad);
        transform.DOScale(Vector3.one, animationDuration).SetEase(Ease.Linear).OnComplete(EnableGrab);

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
    }




    void StartFloatingAnimation(GameObject block)
    {
        // 为每个碎片生成独特的动画参数
        float uniqueFloatingDuration = UnityEngine.Random.Range(floatingDuration * 1.6f, floatingDuration * 2.0f);
        float uniqueRotateDuration = UnityEngine.Random.Range(floatingDuration * 1f, floatingDuration * 1.5f);


        // 生成随机路径点
        Vector3[] path = GenerateRandomPathPoints(block.transform.position, floatingRadius, UnityEngine.Random.Range(3, 8));
        // 设置循环的路径动画，加入旋转和轻微缩放的效果
        block.transform.DOPath(path, uniqueFloatingDuration, PathType.CatmullRom)
            .SetOptions(true)
            .SetEase(Ease.InOutSine) // 使用 Ease.InOutSine 缓动函数来平滑路径动画
            .SetLoops(-1, LoopType.Restart)
            .OnComplete(() => StartFloatingAnimation(block)); // 循环动画

        // 添加旋转动画，每个碎片的旋转速度和方向都不同
        Vector3 rotateAmount = new Vector3(0, 360, 0); // 定义旋转量
        block.transform.DOLocalRotate(rotateAmount, uniqueRotateDuration, RotateMode.LocalAxisAdd)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Restart);

    }

    Vector3[] GenerateRandomPathPoints(Vector3 center, float radius, int pointsCount)
    {
        Vector3[] path = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            // 生成更复杂的路径点
            float angle = UnityEngine.Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float randomRadius = UnityEngine.Random.Range(0.5f * radius, 1.5f * radius);
            float heightAdjustment = Mathf.Sin(i * Mathf.PI / pointsCount) * radius; // 基于正弦波形调整高度，创建更平滑的垂直运动

            path[i] = center + new Vector3(
                Mathf.Cos(angle) * randomRadius,
                heightAdjustment, // 使用基于索引的高度调整，以创建更平滑且有规律的垂直变化
                Mathf.Sin(angle) * randomRadius
            );
        }
        // 可以进一步平滑路径点，或者使用某种算法来调整路径的整体形状
        return path;
    }
}
