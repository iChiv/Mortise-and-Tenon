using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool isInTrigger = false;
    public Transform targetDirection; // Ŀ�귽��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("a") && IsFacingDirection(targetDirection))
        {
            isInTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("a"))
        {
            isInTrigger = false;
        }
    }

    bool IsFacingDirection(Transform direction)
    {
        // ��������ǰ���Ƿ����ָ��Ŀ�귽���X��
        return Vector3.Dot(transform.forward, direction.right) > 0.9f;
    }
}
