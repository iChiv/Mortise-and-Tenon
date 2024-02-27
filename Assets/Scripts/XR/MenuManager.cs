using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            menu.SetActive(true);
        }
        if (OVRInput.GetUp(OVRInput.Button.Start))
        {
            menu.SetActive(false);
        }
    }
}
