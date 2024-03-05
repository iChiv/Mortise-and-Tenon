using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BlockPieces : MonoBehaviour
{
    public Transform correctTransform;
    private Outline outline;

    public bool IsPositionedCorrectly { get; private set; } = false;

    private bool isBeingDragged = false;

    public Camera mainCamera;

    private GameObject handGrab;

    private GameObject distanceHandGrab;

    public AudioClip snapClick;

    private AudioSource audioSource;

    private float pinchTime;
    // [SerializeField]private float unsnapTime = 0.5f;
    
    private FlyToPlayer flyToPlayer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        outline = GetComponent<Outline>();
        
        handGrab = transform.Find("ISDK_HandGrabInteraction").gameObject; 
        distanceHandGrab = transform.Find("ISDK_DistanceHandGrabInteraction").gameObject; 
    }
    
    void Update()
    {
        if (isBeingDragged)
        {
            return;
        }

        if (!IsPositionedCorrectly)
        {
            float distance = Vector3.Distance(transform.position, correctTransform.position);
            float angle = Quaternion.Angle(transform.rotation, correctTransform.rotation);

            if (distance < 0.3f && angle < 90f)
            {
                SnapIntoPlace();
            }
        }
        else
        {
            /*
            bool isPinching = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.5f;
            
            if (isPinching)
            {
                Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
                RaycastHit hit;
                pinchTime += Time.deltaTime;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == transform && pinchTime>unsnapTime)
                    {
                        StartDragging();
                    }
                }
            }
            */
        }
    }

    void SnapIntoPlace()
    {
        transform.position = correctTransform.position;
        transform.rotation = correctTransform.rotation;
        IsPositionedCorrectly = true;
        handGrab.SetActive(false);
        distanceHandGrab.SetActive(false);
        
        //VFX
        
        //SoundFX
        audioSource.PlayOneShot(snapClick);
    }

    // void StartDragging()
    // {
    //     isBeingDragged = true;
    //     IsPositionedCorrectly = false;
    //     handGrab.SetActive(true);
    //     distanceHandGrab.SetActive(true);
    // }

    // public void StopDragging()
    // {
    //     isBeingDragged = false;
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("OVRHand"))
    //     {
    //         outline.enabled = true;
    //     }
    //     else
    //     {
    //         outline.enabled = false;
    //     }
    // }
}
