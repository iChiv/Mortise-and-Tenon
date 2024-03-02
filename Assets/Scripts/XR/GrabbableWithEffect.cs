using UnityEngine;

namespace XR
{
    public class GrabbableWithEffect : OVRGrabbable
    {
        public GameObject grabVFX;
        // Start is called before the first frame update
        public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
        {
            base.GrabBegin(hand, grabPoint);
            grabVFX.SetActive(true);
        }

        public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
        {
            base.GrabEnd(linearVelocity, angularVelocity);
            grabVFX.SetActive(false);
        }
    }
}
