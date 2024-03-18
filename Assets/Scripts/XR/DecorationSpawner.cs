using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{
    public GameObject decorationPrefab; // 装饰品的预制体
    public Transform player; // 玩家的Transform
    public float spawnRate = 5f; // 生成的频率（每秒）
    public float spawnDistance = 10f; // 生成距离玩家的距离
    public Vector2 spawnHeightRange = new Vector2(-5f, 5f); // 生成高度的范围

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f / spawnRate)
        {
            SpawnDecoration();
            timer = 0;
        }
    }

    void SpawnDecoration()
    {
        Vector3 spawnPosition = player.position + (Vector3.forward * spawnDistance) + (Vector3.up * Random.Range(spawnHeightRange.x, spawnHeightRange.y));
        GameObject decoration = Instantiate(decorationPrefab, spawnPosition, Quaternion.identity);
        // 确保装饰物始终朝向玩家
        decoration.transform.LookAt(player);
        // 调整LookAt导致的旋转，使装饰品的正面朝向玩家
        decoration.transform.Rotate(0, 180, 0);
    }
}