using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    public List<Transform> blocks;
    public Vector2 rotationSpeedRange = new Vector2(30.0f, 60.0f); // ��ת�ٶȵ���С�����ֵ
    public Vector2 floatingSpeedRange = new Vector2(0.3f, 0.7f); // �����ٶȵ���С�����ֵ
    public Vector2 floatingAmplitudeRange = new Vector2(0.3f, 0.7f); // �������ȵ���С�����ֵ

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
            blockStates[block] = true; // Ĭ�����з��鶼�Ǽ���״̬

            // Ϊÿ���������ѡ����ת�ٶȡ������ٶȺ͸�������
            rotationSpeeds[block] = Random.Range(rotationSpeedRange.x, rotationSpeedRange.y);
            floatingSpeeds[block] = Random.Range(floatingSpeedRange.x, floatingSpeedRange.y);
            floatingAmplitudes[block] = Random.Range(floatingAmplitudeRange.x, floatingAmplitudeRange.y);
        }
    }

    void Update()
    {
        foreach (Transform block in blocks)
        {
            if (blockStates[block]) // ֻ�е�����״̬Ϊtrueʱ��Ӧ����ת�͸���
            {
                // ʹ��Ϊÿ�����鵥���洢����ת�ٶ�
                block.Rotate(Vector3.up, rotationSpeeds[block] * Time.deltaTime);

                // ʹ��Ϊÿ�����鵥���洢�ĸ����ٶȺ͸�������
                Vector3 startPosition = startPositions[block];
                float tempPosition = Mathf.Sin(Time.fixedTime * Mathf.PI * floatingSpeeds[block]) * floatingAmplitudes[block];
                block.position = startPosition + Vector3.up * tempPosition;
            }
        }
    }

    // �������������������ű��ر�ָ���������ת�͸���
    public void ToggleBlockMovement(Transform block, bool enable)
    {
        if (blockStates.ContainsKey(block))
        {
            blockStates[block] = enable;
        }
    }


}
