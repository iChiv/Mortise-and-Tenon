using UnityEngine;

namespace XR
{
    [RequireComponent(typeof(Rigidbody))]
    public class AttachWithFixedJoint : MonoBehaviour
    {
        public GameObject target; // 目标对象，与之拼接
        public GameObject indicator;
        public float snapDistance = 0.5f; // 拼接触发的最大距离
        public float snapAngle = 30.0f; // 拼接触发的最大角度差

        private void Start()
        {
            indicator.SetActive(false);
        }

        private void Update()
        {
            // 计算与目标对象的距离和角度
            float distance = Vector3.Distance(transform.position, target.transform.position);
            float angle = Quaternion.Angle(transform.rotation, target.transform.rotation);

            // 如果距离和角度都在预设范围内，则进行拼接
            if (distance <= snapDistance && angle <= snapAngle)
            {
                Attach(target);
                indicator.SetActive(true);
            }
        }

        private void Attach(GameObject other)
        {
            // 检查是否已经存在 FixedJoint 组件，如果没有则添加
            FixedJoint joint = gameObject.GetComponent<FixedJoint>();
            if (joint == null)
            {
                joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = other.GetComponent<Rigidbody>();

                // 配置 FixedJoint 参数，如需要
                joint.breakForce = float.MaxValue; // 设置一个很大的值，使得 joint 不会因为力太大而断开
                joint.breakTorque = float.MaxValue;

                // 可选：调整本对象的位置或旋转，使其与目标对象完美对齐
                // transform.position = other.transform.position;
                // transform.rotation = other.transform.rotation;

                // 可选：禁用物理碰撞检测，防止拼接后的物体互相穿透
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other.GetComponent<Collider>());
            }
        }
    }
}