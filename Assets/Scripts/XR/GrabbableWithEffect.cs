using UnityEngine;

namespace XR
{
    public class GrabbableWithEffect : OVRGrabbable
    {
        private Outline outline;

        protected override void Start()
        {
            base.Start();
            outline = GetComponent<Outline>();
        }

        public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
        {
            base.GrabBegin(hand, grabPoint);
            outline.enabled = true;
        }

        public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
        {
            base.GrabEnd(linearVelocity, angularVelocity);
            outline.enabled = false;
        }
    }
}
