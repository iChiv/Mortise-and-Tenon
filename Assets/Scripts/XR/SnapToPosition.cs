using UnityEngine;

namespace XR
{
    public class SnapToPosition : MonoBehaviour
    {
        public Transform target; // 目标位置和旋转
        public float snapDistance = 1.0f; // 吸附触发的最大距离
        public float snapAngle = 30.0f; // 吸附触发的最大角度差，以度为单位
        public float snapSpeed = 0.1f; // 吸附到目标的速度
        public GameObject indicator;

        private bool isSnapping = false;
        private GameObject newParent = null; // 新的父对象

        private void Start()
        {
            indicator.SetActive(false);
        }

        void Update()
        {
            // 计算距离和角度差
            float distance = Vector3.Distance(transform.position, target.position);
            float angle = Quaternion.Angle(transform.rotation, target.rotation);

            // 检测是否进入吸附范围
            if (distance <= snapDistance && angle <= snapAngle)
            {
                isSnapping = true;
                indicator.SetActive(true);
            }

            // 执行吸附
            if (isSnapping)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, snapSpeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, snapSpeed);

                // 如果物体已经非常接近目标位置和旋转，认为吸附完成
                if (distance < 0.01f && angle < 1.0f)
                {
                    isSnapping = false; // 停止吸附逻辑
                    CreateOrMoveToNewParent(); // 创建或移动到新的父对象
                }
            }
        }

        void CreateOrMoveToNewParent()
        {
            // 如果还没有新的父对象，则创建一个
            if (newParent == null)
            {
                newParent = new GameObject("SnappedObjectsParent");
                newParent.transform.position = target.position; // 父对象位置设置为目标位置
                newParent.transform.rotation = target.rotation; // 父对象旋转设置为目标旋转
            }

            // 将当前对象和目标对象设置为新父对象的子对象
            transform.SetParent(newParent.transform, true);
            target.SetParent(newParent.transform, true);

            // 可选：调整物理属性，例如使一个或两个对象的 Rigidbody 为 Kinematic
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // 避免物理上的冲突
            }

            var targetRb = target.GetComponent<Rigidbody>();
            if (targetRb != null)
            {
                targetRb.isKinematic = true; // 同上
            }
        }
    }
}
