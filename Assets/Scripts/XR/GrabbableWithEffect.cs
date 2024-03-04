using System;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

namespace XR
{
    public class GrabbableWithEffect : MonoBehaviour
    {
        public HandGrabInteractor[] handGrabInteractors;
        private Outline outline;

        private void Awake()
        {
            handGrabInteractors = FindObjectsOfType<HandGrabInteractor>();
            foreach (HandGrabInteractor interactor in handGrabInteractors)
            {
                
            }
        }

        private void Update()
        {
            foreach (HandGrabInteractor interactor in handGrabInteractors)
            {
                if (interactor.TargetInteractable != null)
                {
                    MonoBehaviour interactableBehaviour = interactor.TargetInteractable as MonoBehaviour;
                    // GameObject grabbedObject = interactor.TargetInteractable.;
                    if (interactableBehaviour != null)
                    {
                        GameObject grabbedObject = interactableBehaviour.gameObject;
                        outline = grabbedObject.GetComponent<Outline>();
                    }
                }
            }
        }
    }
}
