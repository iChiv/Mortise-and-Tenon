using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToAnchor : MonoBehaviour
{
    public GameObject targetAnchor; // 目标锚点对象
    public float snapDistance = 0.5f; // 吸附的最大距离
    public float snapAngle = 30.0f; // 吸附的最大角度差

    private bool isSnapped = false; // 是否已经吸附

    void Update()
    {
        if (isSnapped) return; // 如果已经吸附，则不执行后续操作

        // 计算当前锚点到目标锚点的距离
        float distance = Vector3.Distance(transform.position, targetAnchor.transform.position);

        if (distance <= snapDistance)
        {
            // 计算角度差
            float angle = Quaternion.Angle(transform.rotation, targetAnchor.transform.rotation);

            if (angle <= snapAngle)
            {
                Snap();
            }
        }
    }

    void Snap()
    {
        // 吸附操作：调整位置和旋转，使当前对象与目标锚点对齐
        transform.position = targetAnchor.transform.position;
        transform.rotation = targetAnchor.transform.rotation;

        // 将当前对象设置为目标锚点对象的子对象
        transform.parent = targetAnchor.transform;

        isSnapped = true; // 标记为已吸附
    }
}