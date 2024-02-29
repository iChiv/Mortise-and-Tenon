using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    public Transform correctTransform;

    private bool isPositionedCorrectly = false;

    private bool isBeingDragged = false;

    public GameObject handGrab;

    public GameObject distanceHandGrab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (isBeingDragged)
        // {
        //     return;
        // }

        if (!isPositionedCorrectly)
        {
            float distance = Vector3.Distance(transform.position, correctTransform.position);
            float angle = Quaternion.Angle(transform.rotation, correctTransform.rotation);

            if (distance < 0.1f && angle < 180f)
            {
                SnapIntoPlace();
            }
        }
        
    }

    void SnapIntoPlace()
    {
        transform.position = correctTransform.position;
        transform.rotation = correctTransform.rotation;
        isPositionedCorrectly = true;
        handGrab.SetActive(false);
        distanceHandGrab.SetActive(false);
        
        //VFX
        //SFX
    }

    void StartDragging()
    {
        isBeingDragged = true;
        isPositionedCorrectly = false;
    }

    public void StopDragging()
    {
        isBeingDragged = false;
    }
}
