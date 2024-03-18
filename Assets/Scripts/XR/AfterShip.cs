using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XR
{
    public class AfterShip : MonoBehaviour
    {
        public Transform ship; // 船的Transform
        public Transform targetPosition; // 目标位置的Transform
        public GameObject promptButton; // 登船提示按钮
        public float moveDuration = 5f; // 移动到目标位置的时间
        public float floatCycleTime = 2f; // 漂浮周期
        public float floatAmplitude = 0.5f; // 漂浮幅度

        public void AfterShipFinished()
        {
            // 船移动到目标位置
            ship.DOMove(targetPosition.position, moveDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                // 在到达后开始漂浮动画
                StartFloating();
                // 显示提示按钮
                promptButton.SetActive(true);
            });
        }

        void StartFloating()
        {
            // 船上下漂浮动画
            ship.DOMoveY(ship.position.y + floatAmplitude, floatCycleTime)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }

        public void LastScene()
        {
            SceneManager.LoadScene("ShipFloating");
        }
    }
}
