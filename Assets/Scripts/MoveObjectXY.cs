using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectXY : MonoBehaviour
{
    public float moveSpeed = 0.05f; // 控制移动速度
    private Rigidbody rb; // 添加对Rigidbody组件的引用

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取Rigidbody组件
    }

    void FixedUpdate() // 使用FixedUpdate而不是Update
    {
        // 检测水平输入（A和D键）
        float horizontalInput = Input.GetAxis("Horizontal"); // A键是-1，D键是1
        // 检测垂直输入（W和S键）
        float verticalInput = Input.GetAxis("Vertical"); // W键是1，S键是-1

        // 根据输入计算移动方向和距离
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 newPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        // 使用Rigidbody.MovePosition更新物体的位置
        rb.MovePosition(newPosition);
    }
}