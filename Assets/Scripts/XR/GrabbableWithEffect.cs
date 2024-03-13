using System;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

namespace XR
{
    public class GrabbableWithEffect : MonoBehaviour
    {
        [SerializeField] private GameObject targetComponentObject; // 组件所在的GameObject

        private IInteractableView _interactableView; // 从Interface对象转换而来的InteractableView

        private AudioSource audioSource;
        public AudioClip audioClip;

        private void Awake()
        {
            _interactableView = GetComponent<IInteractableView>();

            audioSource = targetComponentObject.GetComponent<AudioSource>();

            // 确保目标组件对象已经赋值
            if (targetComponentObject == null)
            {
                Debug.LogError("Target Component Object is not set.", this);
            }
        }

        private void OnEnable()
        {
            if (_interactableView != null)
            {
                // 订阅状态变化事件
                _interactableView.WhenStateChanged += OnInteractableStateChanged;
            }
        }

        private void OnDisable()
        {
            if (_interactableView != null)
            {
                // 取消订阅状态变化事件
                _interactableView.WhenStateChanged -= OnInteractableStateChanged;
            }
        }

        private void OnInteractableStateChanged(InteractableStateChangeArgs args)
        {
            // 检查Interactable的当前状态，并据此启用或禁用目标组件
            if (args.NewState == InteractableState.Select || args.NewState == InteractableState.Hover)
            {
                //SFX
                audioSource.PlayOneShot(audioClip);
                // 激活状态：启用目标组件
                EnableComponent(true);
            }
            else
            {
                // 其他状态：禁用目标组件
                EnableComponent(false);
            }
        }

        private void EnableComponent(bool enable)
        {
            // 获取并设置目标组件的激活状态
            // 这里假设targetComponentObject上附加的是一个MonoBehaviour组件
            var component = targetComponentObject.GetComponent<Outline>();
            if (component != null)
            {
                component.enabled = enable;
            }
            else
            {
                Debug.LogWarning("The target component is not a MonoBehaviour or not found.", this);
            }
        }
    }
}
