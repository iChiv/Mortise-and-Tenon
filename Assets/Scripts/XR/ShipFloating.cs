using DG.Tweening;
using UnityEngine;

namespace XR
{
    public class ShipFloating : MonoBehaviour
    {
        public Transform[] pathPoints; // 路径点数组
        public float moveDuration = 60f; // 完成一圈的时间
        public float floatCycleTime = 2f; // 浮动周期
        public float floatAmplitude = 0.5f; // 浮动幅度

        private void Start()
        {
            MoveAndRotateShip();
            SimulateFloating();
        }

        void MoveAndRotateShip()
        {
            Vector3[] pathPositions = new Vector3[pathPoints.Length];
            Quaternion[] pathRotations = new Quaternion[pathPoints.Length];
            for (int i = 0; i < pathPoints.Length; i++)
            {
                pathPositions[i] = pathPoints[i].position;
                pathRotations[i] = pathPoints[i].rotation;
            }

            // 移动船只
            var pathTween = transform.DOPath(pathPositions, moveDuration, PathType.CatmullRom)
                .SetOptions(true)
                .SetEase(Ease.Linear);

            pathTween.OnWaypointChange(waypointIndex =>
            {
                if (waypointIndex < pathPoints.Length)
                {
                    // 在到达每个路径点时，更新船只的旋转以匹配路径点的旋转
                    var targetRotation = pathRotations[waypointIndex];
                    transform.DORotateQuaternion(targetRotation, floatCycleTime)
                        .SetEase(Ease.InOutSine);
                }
            });
        }


        void SimulateFloating()
        {
            // 模拟浮动效果
            transform.DOMoveY(transform.position.y + floatAmplitude, floatCycleTime)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }

        // int FindClosestPathPointIndex()
        // {
        //     int closestIndex = -1;
        //     float closestDistance = float.MaxValue;
        //     for (int i = 0; i < pathPoints.Length; i++)
        //     {
        //         float distance = Vector3.Distance(transform.position, pathPoints[i].position);
        //         if (distance < closestDistance)
        //         {
        //             closestDistance = distance;
        //             closestIndex = i;
        //         }
        //     }
        //     return closestIndex;
        // }
    }   
}
