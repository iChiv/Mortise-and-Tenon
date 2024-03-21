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
            
            if (targetComponentObject == null)
            {
                Debug.LogError("Target Component Object is not set.", this);
            }
        }

        private void OnEnable()
        {
            if (_interactableView != null)
            {
                _interactableView.WhenStateChanged += OnInteractableStateChanged;
            }
        }

        private void OnDisable()
        {
            if (_interactableView != null)
            {
                _interactableView.WhenStateChanged -= OnInteractableStateChanged;
            }
        }

        private void OnInteractableStateChanged(InteractableStateChangeArgs args)
        {
            if (args.NewState == InteractableState.Select || args.NewState == InteractableState.Hover)
            {
                //need VFX
                audioSource.PlayOneShot(audioClip);
                EnableComponent(true);
            }
            else
            {
                EnableComponent(false);
            }
        }

        private void EnableComponent(bool enable)
        {
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
