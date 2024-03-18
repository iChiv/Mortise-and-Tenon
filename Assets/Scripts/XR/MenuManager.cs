using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor;

namespace XR
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private CanvasGroup menuCanvasGroup;
        [SerializeField] private CanvasGroup menuCanvasGroup2;
        [SerializeField] private GameObject tutorial;
        [SerializeField] private GameObject about;
        [SerializeField] private GameObject restartDialog;
        public Animator fanAnimator;

        void Start()
        {
            ShowTutorial();
            menuCanvasGroup.alpha = 0; // 初始设置菜单内容透明度为0
            menuCanvasGroup2.alpha = 0;
            menu.SetActive(false); // 确保菜单初始状态为隐藏，但不影响Animator的播放
        }
    
        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    menu.SetActive(true);
            //    fanAnimator.SetBool("FanOpen", true);
            //}

            //if (Input.GetKeyDown(KeyCode.K))
            //{
            //    fanAnimator.SetBool("FanOpen", false);
            //    menu.SetActive(false);
            //}

            if (OVRInput.GetDown(OVRInput.Button.Start))
            {
                ToggleMenu();
            }

          
        }

        private void ToggleMenu()
        {
            if (menu.activeSelf)
            {
                // 触发关闭扇子的动画
                fanAnimator.SetBool("FanOpen", false);
                // 获取动画播放长度
                // float animationLength = fanAnimator.GetCurrentAnimatorStateInfo(0).length;
                
                // 动画播放完成后渐隐菜单内容
                menuCanvasGroup2.DOFade(0, 0.5f);
                menuCanvasGroup.DOFade(0, 0.5f).OnComplete(() =>
                {
                    // 渐隐完成后禁用物体
                    menu.SetActive(false);
                });
                
            }
            else
            {
                menu.SetActive(true);
                // 播放开扇子动画
                fanAnimator.SetBool("FanOpen", true);
                // 等待动画播放一定时间后，再渐显菜单内容
                DOVirtual.DelayedCall(0.5f, () => // 延迟时间根据实际动画调整
                {
                    menuCanvasGroup.DOFade(1, 0.5f); // 0.5秒内渐显
                    ShowTutorial();
                });
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void TutorialButton()
        {
            ShowTutorial();
        }

        public void RestartButton()
        {
            restartDialog.SetActive(true); // 显示重新开始对话框
            menuCanvasGroup2.DOFade(1, 0.5f); // 0.5秒内渐显
            tutorial.SetActive(false);
            about.SetActive(false);
        }

        public void AboutUsButton()
        {
            tutorial.SetActive(false);
            menuCanvasGroup2.DOFade(0, 0.5f).OnComplete(() =>
            {
                // 渐隐完成后禁用物体
                restartDialog.SetActive(false);
                about.SetActive(true);
            });
        }

        public void OnRestartYesClicked()
        {
            Restart();
        }

        public void OnRestartNoClicked()
        {
            menuCanvasGroup2.DOFade(0, 0.5f).OnComplete(() =>
            {
                // 渐隐完成后禁用物体
                restartDialog.SetActive(false);
                ShowTutorial();
            });
           
        }

        private void ShowTutorial()
        {
            tutorial.SetActive(true);
            about.SetActive(false);
            menuCanvasGroup2.DOFade(0, 0.5f).OnComplete(() =>
            {
                // 渐隐完成后禁用物体
                restartDialog.SetActive(false);
            });
        }
    }
}
