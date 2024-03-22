using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTimeControll : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public float activateDuration;
    public float waitDuration;
    private float activateTimer;
    private float waitTimer;
    private int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer += Time.deltaTime;
        if(waitTimer >= waitDuration)
        {
            switch (index)
            {
                case 1:
                    gameObject1.GetComponent<Outline>().enabled = true;
                    break;
                case 2:
                    gameObject2.GetComponent<Outline>().enabled = true;
                    break;
                case 3:
                    gameObject3.GetComponent<Outline>().enabled = true;
                    break;
            }
            index += 1;
        }
    }
}
