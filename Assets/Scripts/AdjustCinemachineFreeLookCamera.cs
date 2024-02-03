using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AdjustCinemachineFreeLookCamera : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera; // ָ������Cinemachine FreeLook ���������
    public float zoomSpeed = 0.5f; // �����ٶ�
    public float minRadius = 0.03f; // ��С����뾶
    public float maxRadius = 0.1f; // ������뾶

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        AdjustCameraDistance(scrollInput * zoomSpeed);
    }

    void AdjustCameraDistance(float delta)
    {
        // ����ÿ������İ뾶
        for (int i = 0; i < 3; i++)
        {
            freeLookCamera.m_Orbits[i].m_Radius -= delta; // ���ݻ��������������
            freeLookCamera.m_Orbits[i].m_Radius = Mathf.Clamp(freeLookCamera.m_Orbits[i].m_Radius, minRadius, maxRadius);
        }
    }
}