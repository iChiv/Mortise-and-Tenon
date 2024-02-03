using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AdjustCinemachineFreeLookCamera : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera; // 指向您的Cinemachine FreeLook 相机的引用
    public float zoomSpeed = 0.5f; // 缩放速度
    public float minRadius = 0.03f; // 最小轨道半径
    public float maxRadius = 0.1f; // 最大轨道半径

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        AdjustCameraDistance(scrollInput * zoomSpeed);
    }

    void AdjustCameraDistance(float delta)
    {
        // 调整每个轨道的半径
        for (int i = 0; i < 3; i++)
        {
            freeLookCamera.m_Orbits[i].m_Radius -= delta; // 根据滑轮输入调整距离
            freeLookCamera.m_Orbits[i].m_Radius = Mathf.Clamp(freeLookCamera.m_Orbits[i].m_Radius, minRadius, maxRadius);
        }
    }
}