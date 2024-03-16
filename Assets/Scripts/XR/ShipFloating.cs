using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipFloating : MonoBehaviour
{
    public Transform[] pathPoints; // 路径点数组
    public float moveDuration = 60f; // 完成一圈的时间
    public float floatCycleTime = 2f; // 浮动周期
    public float floatAmplitude = 0.5f; // 浮动幅度

    private void Start()
    {
        MoveShip();
        SimulateFloating();
    }

    void MoveShip()
    {
        // 创建Vector3数组存储路径点位置
        Vector3[] path = new Vector3[pathPoints.Length];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            path[i] = pathPoints[i].position;
        }

        // 让船沿路径移动
        transform.DOPath(path, moveDuration, PathType.CatmullRom)
            .SetOptions(true)
            .SetLookAt(0.01f)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    void SimulateFloating()
    {
        // 模拟浮动效果
        transform.DOMoveY(transform.position.y + floatAmplitude, floatCycleTime)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);

        // 沿Z轴轻微摆动来模拟水流影响
        // 使用DOBlendableLocalRotateBy确保旋转是相对于船的本地坐标系进行的
        transform.DOBlendableLocalRotateBy(new Vector3(0, 0, 2), floatCycleTime, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
