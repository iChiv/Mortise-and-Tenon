using DG.Tweening;
using UnityEngine;

namespace XR
{
    public class ShipFloating : MonoBehaviour
    {
        public Transform[] pathPoints; // 路径点数组
        public float moveDuration = 60f; // 完成一圈的时间
        public float floatCycleTime = 2f; // 浮动周期
        public float floatAmplitude = 0.5f; // 浮动幅度

        // public GameObject[] objectsToShow;
        // public float displayDuration = 10f;
        // public float fadeDuration = 3f;
        // public CanvasGroup endGameFadeGroup;

        private void Start()
        {
            MoveAndRotateShip();
            SimulateFloating();
        }

        void MoveAndRotateShip()
        {
            Vector3[] pathPositions = new Vector3[pathPoints.Length];
            Quaternion[] pathRotations = new Quaternion[pathPoints.Length];
            for (int i = 0; i < pathPoints.Length; i++)
            {
                pathPositions[i] = pathPoints[i].position;
                pathRotations[i] = pathPoints[i].rotation;
            }
            
            if (pathRotations.Length > 0)
            {
                transform.rotation = pathRotations[0];
            }

            // 移动船只
            var pathTween = transform.DOPath(pathPositions, moveDuration, PathType.CatmullRom)
                .SetOptions(true)
                .SetEase(Ease.Linear);

            pathTween.OnWaypointChange(waypointIndex =>
            {
                if (waypointIndex < pathPoints.Length)
                {
                    // 在到达每个路径点时，更新船只的旋转以匹配路径点的旋转
                    var targetRotation = pathRotations[waypointIndex];
                    transform.DORotateQuaternion(targetRotation, floatCycleTime)
                        .SetEase(Ease.InOutSine);
                }
            });
            
            // pathTween.OnComplete(() =>
            // {
            //     // 创建一个序列来组织渐显和渐隐动画
            //     Sequence sequence = DOTween.Sequence();
            //
            //     // 依次添加每个物体的渐显和渐隐动画到序列中
            //     foreach (var obj in objectsToShow)
            //     {
            //         var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            //         if (spriteRenderer == null) continue;
            //
            //         sequence.Append(spriteRenderer.DOFade(1, fadeDuration)) // 渐显
            //             .AppendInterval(displayDuration) // 显示一段时间
            //             .Append(spriteRenderer.DOFade(0, fadeDuration)); // 渐隐
            //     }
            //
            //     // 游戏结束时整个屏幕渐隐到黑
            //     sequence.AppendCallback(() =>
            //     {
            //         endGameFadeGroup.gameObject.SetActive(true);
            //     })
            //     .Append(endGameFadeGroup.DOFade(1, fadeDuration))
            //     .OnComplete(() =>
            //     {
            //         // 可以在这里触发游戏结束的逻辑，比如加载新场景
            //         UnityEngine.SceneManagement.SceneManager.LoadScene("GameMainMenuTT");
            //     });
            // });
        }


        void SimulateFloating()
        {
            // 模拟浮动效果
            transform.DOMoveY(transform.position.y + floatAmplitude, floatCycleTime)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
    }   
}
