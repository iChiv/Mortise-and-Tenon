using System;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

namespace XR
{
    public class GrabbableWithEffect : MonoBehaviour
    {
        public InteractorActiveState InteractorActiveState;
        public InteractorActiveState InteractorActiveState2;
        private Outline outline;

        private void Awake()
        {
            outline = GetComponent<Outline>();
            
        }

        private void Start()
        {
            outline.enabled = false;
        }

        private void Update()
        {
            if (InteractorActiveState.Active || InteractorActiveState2.Active)
            {
                outline.enabled = true;
            }
            else
            {
                outline.enabled = false;
            }
        }
    }
}
