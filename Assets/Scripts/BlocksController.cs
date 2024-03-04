using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    public List<Transform> blocks;
    public Vector2 rotationSpeedRange = new Vector2(30.0f, 60.0f); // 旋转速度的最小和最大值
    public Vector2 floatingSpeedRange = new Vector2(0.3f, 0.7f); // 浮动速度的最小和最大值
    public Vector2 floatingAmplitudeRange = new Vector2(0.3f, 0.7f); // 浮动幅度的最小和最大值

    private Dictionary<Transform, Vector3> startPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, bool> blockStates = new Dictionary<Transform, bool>();
    private Dictionary<Transform, float> rotationSpeeds = new Dictionary<Transform, float>();
    private Dictionary<Transform, float> floatingSpeeds = new Dictionary<Transform, float>();
    private Dictionary<Transform, float> floatingAmplitudes = new Dictionary<Transform, float>();

    void Start()
    {
        foreach (Transform block in blocks)
        {
            startPositions[block] = block.position;
            blockStates[block] = true; // 默认所有方块都是激活状态

            // 为每个方块随机选择旋转速度、浮动速度和浮动幅度
            rotationSpeeds[block] = Random.Range(rotationSpeedRange.x, rotationSpeedRange.y);
            floatingSpeeds[block] = Random.Range(floatingSpeedRange.x, floatingSpeedRange.y);
            floatingAmplitudes[block] = Random.Range(floatingAmplitudeRange.x, floatingAmplitudeRange.y);
        }
    }

    void Update()
    {
        foreach (Transform block in blocks)
        {
            if (blockStates[block]) // 只有当方块状态为true时才应用旋转和浮动
            {
                // 使用为每个方块单独存储的旋转速度
                block.Rotate(Vector3.up, rotationSpeeds[block] * Time.deltaTime);

                // 使用为每个方块单独存储的浮动速度和浮动幅度
                Vector3 startPosition = startPositions[block];
                float tempPosition = Mathf.Sin(Time.fixedTime * Mathf.PI * floatingSpeeds[block]) * floatingAmplitudes[block];
                block.position = startPosition + Vector3.up * tempPosition;
            }
        }
    }

    // 公开方法，允许其他脚本关闭指定方块的自转和浮动
    public void ToggleBlockMovement(Transform block, bool enable)
    {
        if (blockStates.ContainsKey(block))
        {
            blockStates[block] = enable;
        }
    }


}
