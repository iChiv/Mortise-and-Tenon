using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    
    
    
    

    // private bool isMenuOpen = false;

    // public OVRHand leftHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            menu.SetActive(!menu.activeSelf);
        }
        
        // bool isPinching = OVRHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        // var hand = GetComponent<OVRHand>();
        // bool isIndexFingerPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        // float ringFingerPinchStrength = leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
        // OVRHand.TrackingConfidence confidence = leftHand.GetFingerConfidence(OVRHand.HandFinger.Index);
        //
        // if (ringFingerPinchStrength >= 0.8f && !isMenuOpen && isIndexFingerPinching)
        // {
        //     menu.SetActive(true);
        // }
        // else if(ringFingerPinchStrength < 0.7f && isMenuOpen && isIndexFingerPinching)
        // {
        //     menu.SetActive(false);
        // }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TutorialButton()
    {
        //Gif
    }

    public void RestartButton()
    {
        //Display yes or no
    }

    public void AboutUs()
    {
        //Show info
    }
}
