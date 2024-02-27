using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectXY : MonoBehaviour
{
    public float moveSpeed = 0.05f; // �����ƶ��ٶ�
    private Rigidbody rb; // ���Ӷ�Rigidbody���������

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ��ȡRigidbody���
    }

    void FixedUpdate() // ʹ��FixedUpdate������Update
    {
        // ���ˮƽ���루A��D����
        float horizontalInput = Input.GetAxis("Horizontal"); // A����-1��D����1
        // ��ⴹֱ���루W��S����
        float verticalInput = Input.GetAxis("Vertical"); // W����1��S����-1

        // ������������ƶ�����;���
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 newPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        // ʹ��Rigidbody.MovePosition���������λ��
        rb.MovePosition(newPosition);
    }
}