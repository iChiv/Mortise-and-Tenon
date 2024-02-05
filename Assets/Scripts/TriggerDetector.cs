using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool isInTrigger = false;
    public Transform targetDirection; // 目标方向

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
        // 检查物体的前方是否大致指向目标方向的X轴
        return Vector3.Dot(transform.forward, direction.right) > 0.9f;
    }
}
