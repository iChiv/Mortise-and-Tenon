using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTimeControll : MonoBehaviour
{
    public GameObject[] gameObjects; // Array of game objects
    public float activateDuration = 2f; // Duration to keep the outline active
    public float waitDuration = 2f; // Duration to wait before activating the next outline

    private float timer; // Tracks the time
    private int currentIndex = 0; // Index of the current object being processed

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f; // Initialize timer
        ActivateOutline(currentIndex); // Activate outline for the first object
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if the active duration has passed
        if (timer >= activateDuration)
        {
            // Deactivate the current outline
            DeactivateOutline(currentIndex);

            // Move to the next object
            currentIndex++;

            // Reset the timer
            timer = 0f;

            // Check if all objects have been processed
            if (currentIndex >= gameObjects.Length)
            {
                // Optionally loop to the first object or stop the process
                currentIndex = 0; // Loop back to the first object
                // return; // Uncomment this if you don't want to loop
            }

            // Activate the outline for the next object
            ActivateOutline(currentIndex);
        }
    }

    void ActivateOutline(int index)
    {
        if (index < gameObjects.Length)
        {
            Outline outline = gameObjects[index].GetComponent<Outline>();
            if (outline != null)
            {
                outline.enabled = true;
            }
        }
    }

    void DeactivateOutline(int index)
    {
        if (index < gameObjects.Length)
        {
            Outline outline = gameObjects[index].GetComponent<Outline>();
            if (outline != null)
            {
                outline.enabled = false;
            }
        }
    }
}
