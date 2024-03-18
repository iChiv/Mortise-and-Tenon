using UnityEngine;

namespace XR
{
    public class SummonBlocks : MonoBehaviour
    {
        [SerializeField] private float waveThreshold = 1.5f;

        // [SerializeField] private float forceMultiplier = 2f;

        [SerializeField] private float cooldown = 0.5f;

        private float lastWaveTime;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.time < lastWaveTime + cooldown) return;

            Vector3 controllerVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            float speed = controllerVelocity.magnitude;

            bool isWaveForward = Vector3.Dot(controllerVelocity.normalized, controllerRotation * Vector3.forward) > 0;

            if (speed > waveThreshold && !isWaveForward)
            {
                // Vector3
            }
        }
    }
}
